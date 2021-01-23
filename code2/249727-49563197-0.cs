               //Get Example
                var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://abc.def.org/testAPI/api/TestFile");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                var username = "usernameForYourApi";
                var password = "passwordForYourApi";
                var bytes = Encoding.UTF8.GetBytes(username + ":" + password);
                httpWebRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(bytes));
                var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Dts.Events.FireInformation(3, "result from readng stream", result, "", 0, ref fireagain);
                }
                //Post Example
                var httpWebRequestPost = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://abc.def.org/testAPI/api/TestFile");
                httpWebRequestPost.ContentType = "application/json";
                httpWebRequestPost.Method = "POST";
                bytes = Encoding.UTF8.GetBytes(username + ":" + password);
                httpWebRequestPost.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(bytes));
                //POST DATA newtonsoft didnt worked with BIDS 2008 in this test package
                //json https://stackoverflow.com/questions/6201529/how-do-i-turn-a-c-sharp-object-into-a-json-string-in-net
                // fill File model with some test data
                CSharpComplexClass fileModel = new CSharpComplexClass();
                fileModel.CarrierID = 2;
                fileModel.InvoiceFileDate = DateTime.Now;
                fileModel.EntryMethodID = EntryMethod.Manual;
                fileModel.InvoiceFileStatusID = FileStatus.NeedsReview;
                fileModel.CreateUserID = "37f18f01-da45-4d7c-a586-97a0277440ef";
                string json = new JavaScriptSerializer().Serialize(fileModel);
                Dts.Events.FireInformation(3, "reached json", json, "", 0, ref fireagain);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                httpWebRequestPost.ContentLength = byteArray.Length;
                // Get the request stream.  
                Stream dataStream = httpWebRequestPost.GetRequestStream();
                // Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.  
                dataStream.Close();
                // Get the response.  
                WebResponse response = httpWebRequestPost.GetResponse();
                // Display the status.  
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Dts.Events.FireInformation(3, "Display the status", ((HttpWebResponse)response).StatusDescription, "", 0, ref fireagain);
                // Get the stream containing content returned by the server.  
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                Dts.Events.FireInformation(3, "responseFromServer ", responseFromServer, "", 0, ref fireagain);
