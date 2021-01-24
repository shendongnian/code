        internal class CustUserNamePasswordVal : UserNamePasswordValidator
        {
            public override void Validate(string userName, string password)
            {
                if (userName != "jack" || password != "123456")
                {
                    throw new FaultException("Username/Password is not correct");
                }
            }
    }
