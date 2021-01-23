        public override bool ValidateUser(string username, string password)
        {
            Guid parsedUsername;
            if (String.IsNullOrWhiteSpace(password) && Guid.TryParse(username, out parsedUsername))
            {
                return ValidateUser(parsedUsername);
            }
            else
            {
                return db.ValidateUser(username, password);
            }
        }
