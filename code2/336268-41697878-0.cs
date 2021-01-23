    public static bool ValidateQuery(string query)
    {
        return !ValidateRegex("delete", query) && !ValidateRegex("exec", query) && !ValidateRegex("insert", query) && !ValidateRegex("alter", query) &&
               !ValidateRegex("create", query) && !ValidateRegex("drop", query) && !ValidateRegex("truncate", query);
    }
    public static bool ValidateRegex(string term, string query)
    {
        // this regex finds all keywords {0} that are not leading or trailing by alphanumeric 
        return new Regex(string.Format("([^0-9a-z]{0}[^0-9a-z])|(^{0}[^0-9a-z])", term), RegexOptions.IgnoreCase).IsMatch(query);
    }
