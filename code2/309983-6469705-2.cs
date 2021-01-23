    public class User
        {
            private string email;
            private DateTime created;
    
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = ValidateEmail(value);
                }
            }
    
            private string ValidateEmail(string value)
            {
                if (!validEmail(value))
                    throw new NotSupportedException("Not a valid emailadres");     
                    
                return value;
                
    
            }
    
            private bool validEmail(string value)
            {
                return Regex.IsMatch(value, @"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$");
            }
