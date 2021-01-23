        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] //This will cause the response to be in JSON
        public Dictionary<string, string> IsEmailValid(string email)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("Response", AtomicCore.Validation.CheckEmail(email).ToString());
            return response; //Trust ASP.NET to do the formatting here
        }
