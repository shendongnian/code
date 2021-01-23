    public class UserNameClientCredentials : ClientCredentialsElement
    {
        private ConfigurationPropertyCollection properties;
        public override Type BehaviorType
        {
            get { return typeof (ClientCredentials); }
        }
        /// <summary>
        /// Username (required)
        /// </summary>
        public string UserName
        {
            get { return (string) base["userName"]; }
            set { base["userName"] = value; }
        }
        /// <summary>
        /// Password (optional)
        /// </summary>
        public string Password
        {
            get { return (string) base["password"]; }
            set { base["password"] = value; }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                if (properties == null)
                {
                    ConfigurationPropertyCollection baseProps = base.Properties;
                    baseProps.Add(new ConfigurationProperty(
                                      "userName",
                                      typeof (String),
                                      null,
                                      null,
                                      new StringValidator(1),
                                      ConfigurationPropertyOptions.IsRequired));
                    baseProps.Add(new ConfigurationProperty(
                                      "password",
                                      typeof (String),
                                      ""));
                    properties = baseProps;
                }
                return properties;
            }
        }
        protected override object CreateBehavior()
        {
            var creds = (ClientCredentials) base.CreateBehavior();
            creds.UserName.UserName = UserName;
            if (Password != null) creds.UserName.Password = Password;
            ApplyConfiguration(creds);
            return creds;
        }
    }
