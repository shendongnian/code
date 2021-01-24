using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Opc.Ua;   // Install-Package OPCFoundation.NetStandard.Opc.Ua
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System.Threading;
namespace Test_OPC_UA
{
    public partial class Form1 : Form
    {
        //creating a object that encapsulates the netire OPC UA Server related work
        OPCUAClass myOPCUAServer;
        //creating a dictionary of Tags that would be captured from the OPC UA Server
        Dictionary<String, Form1.OPCUAClass.TagClass> TagList = new Dictionary<String, Form1.OPCUAClass.TagClass>();
        public Form1()
        {
            InitializeComponent();
           
            //Add tags to the Tag List, For each tag, you have to define the name of the tag and its address
            //the address can typically be found by browsing the OPC UA Server's tree. In the example below
            // The OPC Server had the following hierarchy: M0401 -> CPU945 -> IBatchOutput
            //i used TBC0401 as a name of the tag, you can use any name
            //add as many tags as you want to capture
            TagList.Add("TBC0401", new Form1.OPCUAClass.TagClass("TBC0401", "M0401.CPU945.iBatchOutput"));
            //to initialize the OPC UA Server, provide the IP Address, Port Number, the list of tags you want to capture
            //in some OPC UA servers and kepware aswell the session can be closed by the OPC UA Server, so its better to 
            //allow the class to reinitiate session periodically, before renewing current sessions are closed
            myOPCUAServer = new OPCUAClass("127.0.0.1", "49320", TagList, true, 1, "2");
            //once the OPC Server has been initialized, you can easily read Tag values and even see when they were
            // updated last time
            //as an example i could read the TBC0401 tag by:
            var tagCurrentValue = TagList["TBC0401"].CurrentValue;
            var tagLastGoodValue = TagList["TBC0401"].LastGoodValue;
            var lastTimeTagupdated = TagList["TBC0401"].LastUpdatedTime;
        }
        public class OPCUAClass
        {
            public string ServerAddress { get; set; }
            public string ServerPortNumber { get; set; }
            public bool SecurityEnabled { get; set; }
            public string MyApplicationName { get; set; }
            public Session OPCSession { get; set; }
            public string OPCNameSpace { get; set; }
            public Dictionary<string, TagClass> TagList { get; set; }
            public bool SessionRenewalRequired { get; set; }
            public double SessionRenewalPeriodMins { get; set; }
            public DateTime LastTimeSessionRenewed { get; set; }
            public DateTime LastTimeOPCServerFoundAlive { get; set; }
            public bool ClassDisposing { get; set; }
            public bool InitialisationCompleted { get; set; }
            private Thread RenewerTHread { get; set; }
            public OPCUAClass(string serverAddres, string serverport, Dictionary<string, TagClass> taglist, bool sessionrenewalRequired, double sessionRenewalMinutes, string nameSpace)
            {
                ServerAddress = serverAddres;
                ServerPortNumber = serverport;
                MyApplicationName = "MyApplication";
                TagList = taglist;
                SessionRenewalRequired = sessionrenewalRequired;
                SessionRenewalPeriodMins = sessionRenewalMinutes;
                OPCNameSpace = nameSpace;
                LastTimeOPCServerFoundAlive = DateTime.Now;
                InitializeOPCUAClient();
                if (SessionRenewalRequired)
                {
                    LastTimeSessionRenewed = DateTime.Now;
                    RenewerTHread = new Thread(renewSessionThread);
                    RenewerTHread.Start();
                }
            }
            //class destructor
            ~OPCUAClass()
            {
                ClassDisposing = true;
                try
                {
                    OPCSession.Close();
                    OPCSession.Dispose();
                    OPCSession = null;
                    RenewerTHread.Abort();
                }
                catch { }
            }
            private void renewSessionThread()
            {
                while (!ClassDisposing)
                {
                    if ((DateTime.Now - LastTimeSessionRenewed).TotalMinutes > SessionRenewalPeriodMins
                        || (DateTime.Now - LastTimeOPCServerFoundAlive).TotalSeconds > 60)
                    {
                        Console.WriteLine("Renewing Session");
                        try
                        {
                            OPCSession.Close();
                            OPCSession.Dispose();
                        }
                        catch { }
                        InitializeOPCUAClient();
                        LastTimeSessionRenewed = DateTime.Now;
                    }
                    Thread.Sleep(2000);
                }
            }
            
            public void InitializeOPCUAClient()
            {
                //Console.WriteLine("Step 1 - Create application configuration and certificate.");
                var config = new ApplicationConfiguration()
                {
                    ApplicationName = MyApplicationName,
                    ApplicationUri = Utils.Format(@"urn:{0}:" + MyApplicationName + "", ServerAddress),
                    ApplicationType = ApplicationType.Client,
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        ApplicationCertificate = new CertificateIdentifier { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault", SubjectName = Utils.Format(@"CN={0}, DC={1}", MyApplicationName, ServerAddress) },
                        TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities" },
                        TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications" },
                        RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates" },
                        AutoAcceptUntrustedCertificates = true,
                        AddAppCertToTrustedStore = true
                    },
                    TransportConfigurations = new TransportConfigurationCollection(),
                    TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                    ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                    TraceConfiguration = new TraceConfiguration()
                };
                config.Validate(ApplicationType.Client).GetAwaiter().GetResult();
                if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
                {
                    config.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted); };
                }
                var application = new ApplicationInstance
                {
                    ApplicationName = MyApplicationName,
                    ApplicationType = ApplicationType.Client,
                    ApplicationConfiguration = config
                };
                application.CheckApplicationInstanceCertificate(false, 2048).GetAwaiter().GetResult();
                //string serverAddress = Dns.GetHostName();
                string serverAddress = ServerAddress; ;
                var selectedEndpoint = CoreClientUtils.SelectEndpoint("opc.tcp://" + serverAddress + ":" + ServerPortNumber + "", useSecurity: SecurityEnabled, operationTimeout: 15000);
                // Console.WriteLine($"Step 2 - Create a session with your server: {selectedEndpoint.EndpointUrl} ");
                OPCSession = Session.Create(config, new ConfiguredEndpoint(null, selectedEndpoint, EndpointConfiguration.Create(config)), false, "", 60000, null, null).GetAwaiter().GetResult();
                {
                    //Console.WriteLine("Step 4 - Create a subscription. Set a faster publishing interval if you wish.");
                    var subscription = new Subscription(OPCSession.DefaultSubscription) { PublishingInterval = 1000 };
                    //Console.WriteLine("Step 5 - Add a list of items you wish to monitor to the subscription.");
                    var list = new List<MonitoredItem> { };
                    //list.Add(new MonitoredItem(subscription.DefaultItem) { DisplayName = "M0404.CPU945.iBatchOutput", StartNodeId = "ns=2;s=M0404.CPU945.iBatchOutput" });
                    list.Add(new MonitoredItem(subscription.DefaultItem) { DisplayName = "ServerStatusCurrentTime", StartNodeId = "i=2258" });
                    foreach (KeyValuePair<string, TagClass> td in TagList)
                    {
                        list.Add(new MonitoredItem(subscription.DefaultItem) { DisplayName = td.Value.DisplayName, StartNodeId = "ns=" + OPCNameSpace + ";s=" + td.Value.NodeID + "" });
                    }
                    list.ForEach(i => i.Notification += OnTagValueChange);
                    subscription.AddItems(list);
                    //Console.WriteLine("Step 6 - Add the subscription to the session.");
                    OPCSession.AddSubscription(subscription);
                    subscription.Create();
                    
                }
               
            }
            public class TagClass
            {
                public TagClass(string displayName, string nodeID)
                {
                    DisplayName = displayName;
                    NodeID = nodeID;
                }
                public DateTime LastUpdatedTime { get; set; }
                public DateTime LastSourceTimeStamp { get; set; }
                public string StatusCode { get; set; }
                public string LastGoodValue { get; set; }
                public string CurrentValue { get; set; }
                public string NodeID { get; set; }
                public string DisplayName { get; set; }
            }
            public void OnTagValueChange(MonitoredItem item, MonitoredItemNotificationEventArgs e)
            {
                foreach (var value in item.DequeueValues())
                {
                    if (item.DisplayName == "ServerStatusCurrentTime")
                    {
                        LastTimeOPCServerFoundAlive = value.SourceTimestamp.ToLocalTime();
                    }
                    else
                    {
                        if (value.Value != null)
                            Console.WriteLine("{0}: {1}, {2}, {3}", item.DisplayName, value.Value.ToString(), value.SourceTimestamp.ToLocalTime(), value.StatusCode);
                        else
                            Console.WriteLine("{0}: {1}, {2}, {3}", item.DisplayName, "Null Value", value.SourceTimestamp, value.StatusCode);
                        if (TagList.ContainsKey(item.DisplayName))
                        {
                            if (value.Value != null)
                            {
                                TagList[item.DisplayName].LastGoodValue = value.Value.ToString();
                                TagList[item.DisplayName].CurrentValue = value.Value.ToString();
                                TagList[item.DisplayName].LastUpdatedTime = DateTime.Now;
                                TagList[item.DisplayName].LastSourceTimeStamp = value.SourceTimestamp.ToLocalTime();
                                TagList[item.DisplayName].StatusCode = value.StatusCode.ToString();
                            }
                            else
                            {
                                TagList[item.DisplayName].StatusCode = value.StatusCode.ToString();
                                TagList[item.DisplayName].CurrentValue = null;
                            }
                        }
                    }
                }
                InitialisationCompleted = true;
            }
        }
        
    }
}
