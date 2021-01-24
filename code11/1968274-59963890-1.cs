    public class LoggedInUserDetails
    {
        public string login_user_name
        {
            get; set;
        }
        public string login_user_id
        {
            get; set;
        }
    }
     var GetResponse = await response2.Content.ReadAsStringAsync();
    //"[{\"login_user_name\":\"Rahul\",\"login_user_id\":\"43\"}]"
     List<LoggedInUserDetails> obj = JsonConvert.DeserializeObject<List<LoggedInUserDetails>>(GetResponse);
     Variables.login_user_name = obj[0].login_user_name;
     Variables.login_user_id= obj[0].login_user_id;
