        internal class CustUserNamePasswordVal : UserNamePasswordValidator
        {
            public override void Validate(string userName, string password)
            {
                if (userName != "jack" || password != "123456")
                {
                    throw new Exception("Username/Password is not correct");
                }
            }
    }
      <serviceCredentials>
                <userNameAuthentication customUserNamePasswordValidatorType="WcfService1.CustUserNamePasswordVal,WcfService1" userNamePasswordValidationMode="Custom"/>
              </serviceCredentials>
