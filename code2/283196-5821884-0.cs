    using System;
    using System.Net;
    using System.IO;
    using System.Text;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    
    class HarvestSample
    {
       //This is used to validate the certificate the server gives you, it allays assumes the cert is valid.
       public static bool Validator (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
         return true;
       }
    
       static void Main(string[] args)
       {
          //setting up the initial request.
          HttpWebRequest request;
          HttpWebResponse response = null;
          StreamReader reader;
          StringBuilder sbSource;
          // 1. Set some variables specific to your account.
          //This is the URL that you will be doing your REST call against. think of it as a function in normal library.
          string uri = "https://yoursubdomain.harvestapp.com/projects";
          string username="youremail@somewhere.com";
          string password="yourharvestpassword";
          string usernamePassword = username + ":" + password;
    
          //This checks the SSL cert that the server will give us, the function is above this one.
          ServicePointManager.ServerCertificateValidationCallback = Validator;
    
          try
          {
             //more setup of the connection
             request = WebRequest.Create(uri) as HttpWebRequest;
             request.MaximumAutomaticRedirections = 1;
             request.AllowAutoRedirect = true;
    
             // 2. It's important that both the Accept and ContentType headers are
             // set in order for this to be interpreted as an API request.
             request.Accept = "application/xml";
             request.ContentType = "application/xml";
             request.UserAgent = "harvest_api_sample.cs";
             // 3. Add the Basic Authentication header with username/password string.
             request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
             //actually perform the GET request
             using (response = request.GetResponse() as HttpWebResponse)
             {
                //Parse out the XML it returned.
                if (request.HaveResponse == true && response != null)
                {
                   reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                   sbSource = new StringBuilder(reader.ReadToEnd());
                   // 4. Print out the XML of all projects for this account.
                   Console.WriteLine(sbSource.ToString());
                }
             }
          }
          catch (WebException wex)
          {
             if (wex.Response != null)
             {
                using (HttpWebResponse errorResponse = (HttpWebResponse)wex.Response)
                {
                   Console.WriteLine(
                         "The server returned '{0}' with the status code {1} ({2:d}).",
                         errorResponse.StatusDescription, errorResponse.StatusCode,
                         errorResponse.StatusCode);
                }
             } else {
                   Console.WriteLine( wex);
    
    }
          } finally {
             if (response != null) { response.Close(); }
          }
       }
    }
