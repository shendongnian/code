        static void Main(string[] args)
        {
            WebClient objWebClient = new WebClient();
            NameValueCollection objNameValueCollection = new NameValueCollection();
            objNameValueCollection.Add("variable1", "test");
            objNameValueCollection.Add("variable2", "ast");
            objNameValueCollection.Add("variable3", "ost");
            byte[] bytes = objWebClient.UploadValues("http://localhost/test.php", "POST", objNameValueCollection);
            Console.Write(Encoding.ASCII.GetString(bytes));
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    
