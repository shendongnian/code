    public class AjaxServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle=WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        public void SaveUser(string userID, string userEmail, string userName)
        {
            //code here handles save
        }
    }
