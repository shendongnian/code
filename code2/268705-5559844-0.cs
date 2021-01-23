              [OperationContract]
              [WebInvoke(Method = "POST", UriTemplate = "DoSomething?siteId={siteId}&configTarget={configTarget}", 
              RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
              bool DoSomething(string itemid, Stream body);
        public bool DoSomething(int siteId, string configTarget, Stream postData)
        {
            string data = new StreamReader(postData).ReadToEnd();
            return data.Length > 0;
        }
