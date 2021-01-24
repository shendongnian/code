        try{
                var response = request.GetResponse();
                var responseStream = response.GetResponseStream();
                string responseString;
                using (var reader = new StreamReader(responseStream))
                {
                    responseString = reader.ReadToEnd();
                }
                var uploadedResponse = JsonConvert.DeserializeObject<UploadedResponse>(responseString);
                return uploadedResponse;
            }
            catch(WebException e){
                var rs = e.Response.GetResponseStream();
                string errorResponseString;
                using (var reader = new StreamReader(rs))
                {
                    errorResponseString = reader.ReadToEnd();
                }
                Console.WriteLine(errorResponseString);  
                return null;  
            }
