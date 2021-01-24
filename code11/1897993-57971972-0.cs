sh
dotnet add package Minio --version 3.1.4
Then the code
c#
using System;
using System.IO;
using Minio;
using Minio.Exceptions;
using Minio.DataModel;
using System.Threading.Tasks;
namespace FileUploader
{
    class FileUpload
    {
        static void Main(string[] args)
        {
            try
            {
                var minio = new MinioClient(
                    "s3.fr-par.scw.cloud",
                    "SCWXXXXXXXXXXX",
                    "xxxxx-xxxx-xxx-xxxxx-xxxx",
                    "fr-par"
                ).WithSSL();
                string [] fileEntries = Directory.GetFiles("/app");
                foreach(string fileName in fileEntries) {
                    FileUpload.Run(minio, fileName).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // File uploader task.
        private async static Task Run(MinioClient minio, string file)
        {
            try
            {
                await minio.PutObjectAsync("my-bucket", Path.GetFileName(file), file, "");
                Console.WriteLine("Successfully uploaded " + file );
            }
            catch (MinioException e)
            {
                Console.WriteLine("File Upload Error: {0}", e.Message);
            }
        }
    }
}
