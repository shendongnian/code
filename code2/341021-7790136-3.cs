        using System;
        using System.Collections.Generic;
        using System.Text;
        using ARMService.ARM;
        using System.Net;
        using System.IO;
        using System.Threading;
        namespace ARMService
        {
          public partial class api : System.Web.Services.Protocols.SoapHttpClientProtocol
        {
        //added "protected overide" to get past the pre-auth issue with VS2008 and above since I'm  running VS2010
        //Now this is in place, you will send the authentication header at the first request. 
        //Since this implementation is using the credentials from the WebClientProtocol, you will be required to set these in advance. 
        //But I guess you were doing that anyways. Furthermore, I chose to only do the pre-authentication if the PreAuthenticate 
        //property was set to true. (deactivated if statement so it will always preauth.)
        //So if you want to consume this service, this is how you would initiate it;
        //api client = new api();
        //client.PreAuthenticate = true;
        //client.Credentials = new NetworkCredential("username", "password");
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
            //		        if (PreAuthenticate)    //removed if statement because I want all items to pre-auth
            //		        {
            NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");
            if (networkCredentials != null)
            {
                byte[] credentialBuffer = new UTF8Encoding().GetBytes(networkCredentials.UserName + ":" + networkCredentials.Password);
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
            }
            else
            {
                throw new ApplicationException("No network credentials");
            }
            //		        }
            return request;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            ArmServiceImplService armService = new ArmServiceImplService();
            // TODO: Replace with live server URL when ready
            armService.Url = "https://HUD will give you the url/ARM/ARM/";
            armService.PreAuthenticate = true;
            NetworkCredential credentials = new NetworkCredential();
            // TODO: Replace with userid/password issued by HUD for HCS system when ready
            credentials.UserName = "yourHUDMXnumber";
            credentials.Password = "yourpassword";
            armService.Credentials = credentials;
            //These three removed per second post and fixed the last issue
            //api client = new api();
            //client.PreAuthenticate = true;
            //client.Credentials = new NetworkCredential(credentials.UserName, credentials.Password);
            
            //removed for now to try only postAgencyData
            //doPing(armService);
            //doGetReference(armService);
            //postSubmissionResponse submissionId = doPostSubmission(armService);
            //fixed
            postSubmissionResponse psr = AgencyData(armService);
            while (dopostAgencyDataResponse(armService, psr) != true)
            {
                // sleep for 60 seconds before checking agin.
                Thread.Sleep(60000);
            }
        }
        private static void doGetReference(ArmServiceImplService armService)
        {
            getReference getReference = new getReference();
            // TODO: Replace 80000 with your agency HCS id.
            getReference.agcHcsId = 80000;
            getReference.referenceId = 0;
            referenceItem[] referenceItems = armService.getReference(getReference);
            foreach (referenceItem referenceItem in referenceItems)
            {
                Console.WriteLine(referenceItem.id);
                Console.WriteLine(referenceItem.name);
                Console.WriteLine(referenceItem.longDesc);
                Console.WriteLine(referenceItem.shortDesc);
            }
        }
        private static void doPing(ArmServiceImplService armService)
        {
            ping pingIn = new ping();
            // TODO: Replace 80000 with your agency HCS id.
            pingIn.agcHcsId = 80000;
            string pingString = armService.ping(pingIn);
            Console.WriteLine(pingString);
        }
        private static postSubmissionResponse AgencyData(ArmServiceImplService armService)
        {
            postAgencyData AgencyData = new postAgencyData();
            submissionHeader40 header = new submissionHeader40();
            // TODO: Replace 80000 with your agency HCS id.
            header.agcHcsId = 80000;
            header.agcName = "Your Agency Name";
            // TODO: Replace 8 with your CMS vendor id issued to you by ARM Development Team.
            header.fiscalYearId = 17;
            header.reportingPeriodId = 3;
            header.cmsVendorId = yourVendorNUmber;
            AgencyData.submissionHeader40 = header;
            // TODO: Replace fake databag with valid databag of your own
            FileStream file = new FileStream("c:/Users/Public/Documents/AgencyProfileData.xml", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            string str = sr.ReadToEnd();
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            AgencyData.submissionData = encoding.GetBytes(str);
            //fixed
            postSubmissionResponse psr = armService.postAgencyData(AgencyData);
            Console.WriteLine("Submitted Data returned id : " + psr.submissionId);
            return psr;
        }
        private static Boolean dopostAgencyDataResponse(ArmServiceImplService armService,
            postSubmissionResponse postAgencyDataResponse)
        {
            getSubmissionInfo getSubmissionInfo = new getSubmissionInfo();
            // TODO: Replace 80000 with your agency HCS id.
            getSubmissionInfo.agcHcsId = 80000;
            getSubmissionInfo.submissionId = postAgencyDataResponse.submissionId;
            getSubmissionInfoResponse response = armService.getSubmissionInfo(getSubmissionInfo);
            Console.WriteLine("SubmissionInfo Status Date = " + response.statusDate);
            Console.WriteLine("SubmissionInfo Status Message = " + response.statusMessage);
            // if Done or Error returned, then return true to stop polling server.
            if (response.statusMessage.Equals("DONE") || response.statusMessage.Contains("ERROR"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    }
