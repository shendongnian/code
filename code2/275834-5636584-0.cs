    namespace TextWCF
    {
    [ServiceContract]
    public interface IShortMessageService
    {
        [WebInvoke(UriTemplate = "invoke", Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        string PostSMS(Stream input);
    
    }
    }
    
    [OperationBehavior]
        public string PostSMS(Stream input)
        {
    
            StreamReader sr = new StreamReader(input);
            string s = sr.ReadToEnd();
            sr.Dispose();
            NameValueCollection qs = HttpUtility.ParseQueryString(s);
    
            string user = Convert.ToString(qs["user"]);
            string password = qs["password"];
            string api_id = qs["api_id"];
            string to = qs["to"];
            string text = qs["text"];
            string from = qs["from"];
    
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.OK;
            WebOperationContext.Current.OutgoingResponse. = HttpStatusCode.OK;
    
            return "Some String";
        }
