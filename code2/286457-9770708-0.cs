        public Boolean CusipValidation(string sCusip)
        {
            string Cusippattern = @"^([0-9]){3}([a-zA-Z0-9]){6}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(sCusip, Cusippattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase) && sCusip != string.Empty)
                return false;
            else
                return true;
        }
