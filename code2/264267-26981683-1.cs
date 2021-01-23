        /// <summary>
        /// Validates the string is an Email Address...
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddress(this string emailAddress)
        {
            var valid = true;
            // assume semi-colon delimited list of emails
            string[] emails = emailAddress.Split(';');
            foreach (string e in emails)
            {
                var email = e.Trim();
                if (e.Length > 0 && valid) // if valid == false, no reason to continue checking
                {
                    // Cannot start with period.
                    // In the name, valid characters are:  a-z 0-9 ! # _ % & ' " = ` { } ~ - + * ? ^ | / $
                    // Cannot have period immediately before @ sign.
                    // Cannot have two @ symbols
                    // In the domain, valid characters are: a-z 0-9 - .
                    // Domain cannot start with a period or dash
                    // Domain name must be 2 characters.. not more than 64 characters
                    // Domain cannot end with a period or dash.
                    valid = Regex.IsMatch(email, @"\A([a-z0-9!#_%&'""=`{}~\-\+\*\?\^\|\/\$])+([a-z0-9!#_%&'""=`{}~\.\-\+\*\?\^\|\/\$])+([a-z0-9!#_%&'""=`{}~\-\+\*\?\^\|\/\$])+@{1}([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z0-9]{2,64}\z");
                }
            }
            // TODO: catch double periods
            // NOTE: end of regex can be modified to lengthen the length of the top-level domain to be longer than 64 characters
            return valid;
        }
