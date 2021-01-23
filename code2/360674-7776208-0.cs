    public class Person
    {
        public event EventHandler<string> PhoneNumberChanged;
    
        private string _name;
        private string _phone;
    
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }
    
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
    
                if (this.PhoneNumberChanged != null)
                {
                    this.PhoneNumberChanged(this._phone);
                }
            }
        }
    }
