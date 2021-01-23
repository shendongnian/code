    class TestService
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57211/Service1.svc/getcar/1");
            WebResponse response = request.GetResponse();
            string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(result);
            string requestData = "{\"ID\":1,\"Make\":\"Ferrari\"}";
            byte[] data = Encoding.UTF8.GetBytes(requestData);
            request = (HttpWebRequest)WebRequest.Create("http://localhost:57211/Service1.svc/updatecar/1");
            request.Method = "POST";
            request.ContentType = "application/json";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();
            response = request.GetResponse();
            result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Console.WriteLine(result);
        }
    }
