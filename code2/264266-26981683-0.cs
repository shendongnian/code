       /// <summary>
        /// Validates the string is an Email Address...
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddress(this string emailAddress)
        {
            // Validate only the first email in a semi-colon delimited list of emails
            emailAddress = emailAddress.Split(';')[0].Trim();
            // Cannot start with period.
            // In the name, valid characters are:  a-z 0-9 ! # _ % & ' " = ` { } ~ - + * ? ^ | / $
            // Cannot have period immediately before @ sign.
            // Cannot have two @ symbols
            // Cannot have period immediately after @ sign.
            // In the domain, valid characters are: a-z 0-9 - .
            // Domain cannot start with a period or dash
            // Domain name must be 2 characters.. not more than 64 characters
            // Domain cannot end with a period or dash.
            return Regex.IsMatch(emailAddress, @"\A([a-z0-9!#_%&'""=`{}~\-\+\*\?\^\|\/\$])+([a-z0-9!#_%&'""=`{}~\.\-\+\*\?\^\|\/\$])+([a-z0-9!#_%&'""=`{}~\-\+\*\?\^\|\/\$])+@{1}([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z0-9]{2,64}\z");
            // TODO: catch double periods
            // NOTE: can be modified to lengthen the length of the top-level domain
        }
