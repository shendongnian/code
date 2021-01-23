        [System.Web.Services.WebMethod]
        public static string GetChatData()
        {
            // Some additional code; you will probably also need to pass a paramter for the chat id
            var sbChatData = new System.Text.StringBuilder(1000);
            while (dr.read())
            {
                sbChatData.AppendLine(dr[0].ToString());
            }
            return sbChatData.ToString();
        }
