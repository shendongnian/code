        private static string _password;
        public static string Password
        {
            get
            {
                if (_password.IsNullOrWhiteSpace())
                    throw new NullReferenceException(string.Format("{0} {1}",
                        "Password was neither found in the .cfg file nor the",
                        "command line arguments."));
                return _password;
            }
            set
            {
                _password = value ?? string.Empty;
            }
        }
