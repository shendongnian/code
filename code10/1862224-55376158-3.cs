    namespace UnNamed Project
    {
        class SuperUser : User
        {
            private ILoginHandler _loginHandler;
    
            public SuperUser(string name, string password) : base(name, 10)
            {
                _loginHandler = new FaceLogin(password);
            }
    
            public override bool Login()
            {
                return _loginHandler.HandleLogin();
            }
        }
    }
