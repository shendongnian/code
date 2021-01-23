        private bool WildcardMatch(String s, String wildcard, bool case_sensitive)
        {
            // Replace the * with an .* and the ? with a dot. Put ^ at the
            // beginning and a $ at the end
            String pattern = "^" + Regex.Escape(wildcard).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
            // Now, run the Regex as you already know
            Regex regex;
            if(case_sensitive)
                regex = new Regex(pattern);
            else
                regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return(regex.IsMatch(s));
        } 
