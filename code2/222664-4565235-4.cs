        public class MyIdentity : IIdentity
        {
                public MyIdentity(string username)
                {
                   _username = username;//auth from the DB here.
                   //load up the Roles from db or whatever
                }
                string _username;
                public User UserData { get; set; }
                #region IIdentity Members
                public string AuthenticationType
                {
                    get { return "MyOwn.Authentication"; }
                }
                public bool IsAuthenticated
                {
                    get { return true; }
                }
                public string Name
                {
                    get { return _username; }
                }
                #endregion
                public string[] Roles
                {
                    get
                    {
                        return //get a list of roles as strings from your Db or something.
                    }
                }
        }
