        public class LoginMessage : ICommandMessage<LoginResult>
    	{
    		public LoginResult Result { get; set; }
    		public LoginViewModel Input { get; set; }
    	}
