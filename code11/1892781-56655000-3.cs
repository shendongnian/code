        using System;
        using System.IO;
        using System.Net;
        namespace FtpDirectoryListing
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var uriBuilder = new UriBuilder();
                    uriBuilder.Scheme = "ftp";
                    uriBuilder.Host = "speedtest.tele2.net";
                    var request = (FtpWebRequest)WebRequest.Create(uriBuilder.Uri);
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    var response = (FtpWebResponse)request.GetResponse();
                    var responseStream = response.GetResponseStream();
                    var reader = new StreamReader(responseStream);
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    Console.WriteLine($"Directory List Complete, status {response.StatusDescription}");
                    reader.Close();
                    response.Close();
                }
            }
        }
