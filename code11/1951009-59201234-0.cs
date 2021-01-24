        public class LoginResult: MvcContrib.PortableAreas.ICommandResult
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string Username { get; set; }
        }
