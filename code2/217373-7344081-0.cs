    using System;
    using System.Windows.Forms;
    using Microsoft.Exchange.WebServices.Data;
    
    namespace test3
    {
        public partial class Form1 : Form
        {
            ExchangeService service = null;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                service = new ExchangeService();
                service.Url = new Uri("https://<exchange_server>/EWS/Exchange.asmx");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                NameResolutionCollection nameResolutions = service.ResolveName(
                    "<group_name>",
                    ResolveNameSearchLocation.DirectoryOnly,
                    true);
    
                foreach (NameResolution nameResolution in nameResolutions)
                {
                    ExpandGroupResults groupResults = service.ExpandGroup(nameResolution.Mailbox.Address);
                    foreach (EmailAddress member in groupResults.Members)
                    {
                        Console.WriteLine(member.Name + " <" + member.Address + ">");
                    }
                }
            }
        }
    }
