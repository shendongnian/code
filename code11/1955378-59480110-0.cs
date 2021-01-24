cs
using System;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using Google.Apis.Services;
namespace Google.Apis.Samples.PlusServiceAccount
{
    /// <summary>
    /// This sample demonstrates the simplest use case for a Service Account service.
    /// The certificate needs to be downloaded from the Google API Console
    /// <see cref="https://console.developers.google.com/">
    ///   "Create another client ID..." -> "Service Account" -> Download the certificate,
    ///   rename it as "key.p12" and add it to the project. Don't forget to change the Build action
    ///   to "Content" and the Copy to Output Directory to "Copy if newer".
    /// </summary>
    public class Program
    {
        // A known public activity.
        private static String ACTIVITY_ID = "z12gtjhq3qn2xxl2o224exwiqruvtda0i";
        public static void Main(string[] args)
        {
            Console.WriteLine("Plus API - Service Account");
            Console.WriteLine("==========================");
            String serviceAccountEmail = "SERVICE_ACCOUNT_EMAIL_HERE";
            var certificate = new X509Certificate2(@"key.p12", "notasecret", X509KeyStorageFlags.Exportable);
            ServiceAccountCredential credential = new ServiceAccountCredential(
               new ServiceAccountCredential.Initializer(serviceAccountEmail)
               {
                   Scopes = new[] { PlusService.Scope.PlusMe }
               }.FromCertificate(certificate));
            // Create the service.
            var service = new PlusService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Plus API Sample",
            });
            Activity activity = service.Activities.Get(ACTIVITY_ID).Execute();
            Console.WriteLine("  Activity: " + activity.Object.Content);
            Console.WriteLine("  Video: " + activity.Object.Attachments[0].Url);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
After obtaining the credentials and creating the `DriveService` instance, you simply need to call the [`Files: create`](https://developers.google.com/drive/api/v3/reference/files/create) endpoint specifying as parents of the created file (see the ["Request body"](https://developers.google.com/drive/api/v3/reference/files/create#request-body) spec) the root of the Shared drive, or a folder within the shared drive.
As an example:
cs
var fileMetadata = new File();
fileMetadata.Name = "My File";
fileMetadata.Parents = new List<string> { "YOUR_SHARED_DRIVE_FOLDER_ID" };
FilesResource.CreateMediaUpload request;
using (var stream = new System.IO.FileStream("your_folder/your_file",
                        System.IO.FileMode.Open))
{
    request = driveService.Files.Create(
        fileMetadata, stream);
    request.Fields = "id";
    request.Upload();
}
var file = request.ResponseBody;
Console.WriteLine("File ID: " + file.Id);
### Reference
You can learn more about service accounts here:
+ https://developers.google.com/identity/protocols/OAuth2ServiceAccount
+ https://developers.google.com/api-client-library/dotnet/guide/aaa_oauth#service-account
