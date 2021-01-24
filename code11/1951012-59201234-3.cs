        public class LoginHandler : MvcContrib.PortableAreas.MessageHandler<Portable.LoginMessage>
        {
            public override void Handle(Portable.LoginMessage message)
            {
                if (IsValidLogin(message.Input.Username, message.Input.Password))
                {
                    message.Result.Success = true;
                    message.Result.Username = message.Input.Username;
                }
                else
                {
                    message.Result.Message = "Username or Password was incorrect";
                }
            }
            private bool IsValidLogin(string username, string password)
            {
                // TODO: Replace with actual authentication
                return username.Equals("admin") && password.Equals("password");
            }
        }
