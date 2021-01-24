        using Google.Apis.Authentication;
        using Google.Apis.Drive.v2;
        using Google.Apis.Drive.v2.Data;
        
        using System.Net;
        
        public class DownLoadFromGDrive{
        
          /// <param name="authenticator">
          /// Authenticator responsible for creating authorized web requests.
          /// </param>
          /// <param name="file">Drive File instance.</param>
          /// <returns>File's content if successful, null otherwise.</returns>
          public static System.IO.Stream DownloadFile(
              IAuthenticator authenticator, File file) {
            if (!String.IsNullOrEmpty(file.DownloadUrl)) {
              try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                    new Uri(file.DownloadUrl));
                authenticator.ApplyAuthenticationToRequest(request);
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK) {
                  return response.GetResponseStream();
                } 
                else 
               {
                  return null;
                }
              } 
              catch (Exception e) 
              {
                return null;
              }
            } 
          }
        }
