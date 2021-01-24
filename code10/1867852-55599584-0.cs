    using System;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Web.UI;
    namespace CGIX_2
    {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = MyCertHandler;
                try
                {
                    var sr = new mil.uscg.psix.PSIXData();
                    var data = sr.getVesselSummaryXMLString("", "A STEVE CROWLEY", "", "", "", "", "", "");
                }
                catch (Exception ex)
                {
                
                }
            }
            static bool MyCertHandler(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors error)
            {
                // Ignore errors
                return true;
            }
        }
    }
