        public void PutObject(string postUrl, object payload)
            {
                var request = (HttpWebRequest)WebRequest.Create(postUrl);
                request.Method = "PUT";
                request.ContentType = "application/xml";
                if (payload !=null)
                {
                    request.ContentLength = Size(payload);
                    Stream dataStream = request.GetRequestStream();
                    Serialize(dataStream,payload);
                    dataStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString();
            }
     
    public void Serialize(Stream output, object input)
                {
                    var ser = new DataContractSerializer(input.GetType());
                    ser.WriteObject(output, input);
                }
