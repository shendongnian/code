    public class User {
        //Usery properties here, and...
        private string _password;
        public string Password {
            get {
                return _password;
            }
            set {
                _password = SomeHashingFunction(value);
            }
        }
    }
