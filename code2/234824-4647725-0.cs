    class Program
    {
        static void Main(string[] args)
        {
            var webclient = new WebClient();
            var valueToSend = new Message("some data", "some other data");
            var parameters = new NameValueCollection 
              {
                {"Key", Jsonify(valueToSend)}
              };
            webclient.UploadValues(
              "http://localhost:8888/Ny", 
              "POST", 
              parameters);
        }
        static string Jsonify(object data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(data.GetType());
                ser.WriteObject(ms,data);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
        
    }
