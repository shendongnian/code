    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Azure.Storage.Blobs;
    using System.Net.Http;
    using System.Globalization;
    using System.Net.Http.Headers;
    using System.Collections.Specialized;
    using System.Web;
    using System.Security.Cryptography;
    
    namespace ConsoleApp1
    {
        class Program
        {
            const string accountName = "myaccountname";
            const string accountKey = "myaccountkey";
            const string shareName = "test";
            const string directory = "test";
            
            static void Main(string[] args)
            {
                Uri storageUri = new Uri($"https://{accountName}.file.core.windows.net/{shareName}/{directory}?restype=directory");
    
                using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, storageUri)
                { Content = new StringContent("") })
                {
                    var now = DateTime.UtcNow;
                    httpRequestMessage.Headers.Add("x-ms-date", now.ToString("R", CultureInfo.InvariantCulture));
                    httpRequestMessage.Headers.Add("x-ms-version", "2017-04-17");
                    httpRequestMessage.Headers.Add("x-ms-content-length", "200");
                    httpRequestMessage.Headers.Add("x-ms-type", "file");
    
                    // Add the authorization header.
                    httpRequestMessage.Headers.Authorization = AzureStorageAuthenticationHelper.GetAuthorizationHeader(
                        accountName, accountKey, now, httpRequestMessage);
    
                    // Send the request.
                    using (var response = new HttpClient().SendAsync(httpRequestMessage).GetAwaiter().GetResult())
                    {
                        Console.WriteLine("Directory created successfully.");
                    }
                }
                
            }
        }
    
        internal static class AzureStorageAuthenticationHelper
        {
            /// <summary>
            /// This creates the authorization header. This is required, and must be built 
            ///   exactly following the instructions. This will return the authorization header
            ///   for most storage service calls.
            /// Create a string of the message signature and then encrypt it.
            /// </summary>
            /// <param name="storageAccountName">The name of the storage account to use.</param>
            /// <param name="storageAccountKey">The access key for the storage account to be used.</param>
            /// <param name="now">Date/Time stamp for now.</param>
            /// <param name="httpRequestMessage">The HttpWebRequest that needs an auth header.</param>
            /// <param name="ifMatch">Provide an eTag, and it will only make changes
            /// to a blob if the current eTag matches, to ensure you don't overwrite someone else's changes.</param>
            /// <param name="md5">Provide the md5 and it will check and make sure it matches the blob's md5.
            /// If it doesn't match, it won't return a value.</param>
            /// <returns></returns>
            internal static AuthenticationHeaderValue GetAuthorizationHeader(
               string storageAccountName, string storageAccountKey, DateTime now,
               HttpRequestMessage httpRequestMessage, string ifMatch = "", string md5 = "")
            {
                // This is the raw representation of the message signature.
                var method = httpRequestMessage.Method;
    
                // content length
                var contentLength = string.Empty;
                if (!(method == HttpMethod.Get || method == HttpMethod.Head))
                {
                    var length = httpRequestMessage.Content?.Headers.ContentLength;
    
                    if (length != null && length > 0)
                    {
                        contentLength = length.ToString();
                    }
                }
    
                String messageSignature = String.Format("{0}\n\n\n{1}\n{5}\n{7}\n{6}\n\n{2}\n\n\n\n{3}{4}",
                          method.ToString().ToUpper(),
                          contentLength,
                          ifMatch,
                          GetCanonicalizedHeaders(httpRequestMessage),
                          GetCanonicalizedResource(httpRequestMessage.RequestUri, storageAccountName),
                          md5,
                          string.Empty,
                          httpRequestMessage.Content?.Headers.ContentType.ToString() ?? string.Empty);
    
                // Now turn it into a byte array.
                var signatureBytes = Encoding.UTF8.GetBytes(messageSignature);
    
                // Create the HMACSHA256 version of the storage key.
                var SHA256 = new HMACSHA256(Convert.FromBase64String(storageAccountKey));
    
                // Compute the hash of the SignatureBytes and convert it to a base64 string.
                var signature = Convert.ToBase64String(SHA256.ComputeHash(signatureBytes));
    
                // This is the actual header that will be added to the list of request headers.
                // You can stop the code here and look at the value of 'authHV' before it is returned.
                var authHV = new AuthenticationHeaderValue("SharedKey",
                    storageAccountName + ":" + signature);
                return authHV;
            }
    
            /// <summary>
            /// Put the headers that start with x-ms in a list and sort them.
            /// Then format them into a string of [key:value\n] values concatenated into one string.
            /// (Canonicalized Headers = headers where the format is standardized).
            /// </summary>
            /// <param name="httpRequestMessage">The request that will be made to the storage service.</param>
            /// <returns>Error message; blank if okay.</returns>
            private static string GetCanonicalizedHeaders(HttpRequestMessage httpRequestMessage)
            {
                var headers = from kvp in httpRequestMessage.Headers
                              where kvp.Key.StartsWith("x-ms-", StringComparison.OrdinalIgnoreCase)
                              orderby kvp.Key
                              select new { Key = kvp.Key.ToLowerInvariant(), kvp.Value };
    
                StringBuilder sb = new StringBuilder();
    
                // Create the string in the right format; this is what makes the headers "canonicalized" --
                //   it means put in a standard format. http://en.wikipedia.org/wiki/Canonicalization
                foreach (var kvp in headers)
                {
                    StringBuilder headerBuilder = new StringBuilder(kvp.Key);
                    char separator = ':';
    
                    // Get the value for each header, strip out \r\n if found, then append it with the key.
                    foreach (string headerValues in kvp.Value)
                    {
                        string trimmedValue = headerValues.TrimStart().Replace("\r\n", String.Empty);
                        headerBuilder.Append(separator).Append(trimmedValue);
    
                        // Set this to a comma; this will only be used 
                        //   if there are multiple values for one of the headers.
                        separator = ',';
                    }
                    sb.Append(headerBuilder.ToString()).Append("\n");
                }
                return sb.ToString();
            }
    
            /// <summary>
            /// This part of the signature string represents the storage account 
            ///   targeted by the request. Will also include any additional query parameters/values.
            /// For ListContainers, this will return something like this:
            ///   /storageaccountname/\ncomp:list
            /// </summary>
            /// <param name="address">The URI of the storage service.</param>
            /// <param name="accountName">The storage account name.</param>
            /// <returns>String representing the canonicalized resource.</returns>
            private static string GetCanonicalizedResource(Uri address, string storageAccountName)
            {
                // The absolute path is "/" because for we're getting a list of containers.
                StringBuilder sb = new StringBuilder("/").Append(storageAccountName).Append(address.AbsolutePath);
    
                // Address.Query is the resource, such as "?comp=list".
                // This ends up with a NameValueCollection with 1 entry having key=comp, value=list.
                // It will have more entries if you have more query parameters.
                NameValueCollection values = HttpUtility.ParseQueryString(address.Query);
    
                foreach (var item in values.AllKeys.OrderBy(k => k))
                {
                    sb.Append('\n').Append(item).Append(':').Append(values[item]);
                }
    
                return sb.ToString();
    
            }
        }
    }
