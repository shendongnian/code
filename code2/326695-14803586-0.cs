        private bool WildcardMatch(String s, String wildcard, bool case_sensitive)
        {
            String pattern = "^" + Regex.Escape(wildcard).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
            Regex regex;
            if(case_sensitive)
                regex = new Regex(pattern);
            else
                regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return(regex.IsMatch(s));
        } 
