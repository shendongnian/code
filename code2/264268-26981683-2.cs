        /// <summary>
        /// Validates the string is an Email Address...
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddress(this string emailAddress)
        {
            var valid = true;
            var isnotblank = false;
            var email = emailAddress.Trim();
            if (email.Length > 0)
            {
                // Email Address Cannot start with period.
                // Name portion must be at least one character
                // In the Name, valid characters are:  a-z 0-9 ! # _ % & ' " = ` { } ~ - + * ? ^ | / $
                // Cannot have period immediately before @ sign.
                // Cannot have two @ symbols
                // In the domain, valid characters are: a-z 0-9 - .
                // Domain cannot start with a period or dash
                // Domain name must be 2 characters.. not more than 256 characters
                // Domain cannot end with a period or dash.
                // Domain must contain a period
                isnotblank = true;
                valid = Regex.IsMatch(email, @"\A([\w!#%&'""=`{}~\.\-\+\*\?\^\|\/\$])+@{1}\w+([-.]\w+)*\.\w+([-.]\w+)*\z", RegexOptions.IgnoreCase) &&
                    !email.StartsWith("-") &&
                    !email.StartsWith(".") &&
                    !email.EndsWith(".") && 
                    !email.Contains("..") &&
                    !email.Contains(".@") &&
                    !email.Contains("@.");
            }
            return (valid && isnotblank);
        }
        /// <summary>
        /// Validates the string is an Email Address or a delimited string of email addresses...
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddressDelimitedList(this string emailAddress, char delimiter = ';')
        {
            var valid = true;
            var isnotblank = false;
            string[] emails = emailAddress.Split(delimiter);
            foreach (string e in emails)
            {
                var email = e.Trim();
                if (email.Length > 0 && valid) // if valid == false, no reason to continue checking
                {
                    isnotblank = true;
                    if (!email.IsValidEmailAddress())
                    {
                        valid = false;
                    }
                }
            }
            return (valid && isnotblank);
        }
