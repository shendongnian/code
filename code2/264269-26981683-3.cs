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
                valid = Regex.IsMatch(email, Regex.EmailPattern, RegexOptions.IgnoreCase) &&
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
        public class Regex
        {
            /// <summary>
            /// Set of Unicode Characters currently supported in the application for email, etc.
            /// </summary>
            public static readonly string UnicodeCharacters = "ÀàÂâÆæÇçÈèÉéÊêËëÎîÏïÔôŒœÙùÛûÜü«»€₣äÄöÖüÜß"; // German and French
            /// <summary>
            /// Set of Symbol Characters currently supported in the application for email, etc.
            /// Needed if a client side validator is being used.
            /// Not needed if validation is done server side.
            /// The difference is due to subtle differences in Regex engines.
            /// </summary>
            public static readonly string SymbolCharacters = @"!#%&'""=`{}~\.\-\+\*\?\^\|\/\$";
            /// <summary>
            /// Regular Expression string pattern used to match an email address.
            /// The following characters will be supported anywhere in the email address:
            /// ÀàÂâÆæÇçÈèÉéÊêËëÎîÏïÔôŒœÙùÛûÜü«»€₣äÄöÖüÜß[a - z][A - Z][0 - 9] _
            /// The following symbols will be supported in the first part of the email address(before the @ symbol):
            /// !#%&'"=`{}~.-+*?^|\/$
            /// Emails cannot start or end with periods,dashes or @.
            /// Emails cannot have two @ symbols.
            /// Emails must have an @ symbol followed later by a period.
            /// Emails cannot have a period before or after the @ symbol.
            /// </summary>
            public static readonly string EmailPattern = String.Format(
                @"^([\w{0}{2}])+@{1}[\w{0}]+([-.][\w{0}]+)*\.[\w{0}]+([-.][\w{0}]+)*$",                     //  @"^[{0}\w]+([-+.'][{0}\w]+)*@[{0}\w]+([-.][{0}\w]+)*\.[{0}\w]+([-.][{0}\w]+)*$",
                UnicodeCharacters,
                "{1}",
                SymbolCharacters
            );
        }
