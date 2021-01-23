        private bool IsValidMultipleEmail1(string value)
        {
            public Regex _Regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            string[] _emails = value.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string email in _emails)
            {
                if (!_Regex.IsMatch(email))
                    return false;
            }
            return true;
        }
