    public bool IsValidEmailAddress(string s)
    {
        if (string.IsNullOrEmpty(s))
            return false;
        else
        {
            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regex.IsMatch(s) && !s.EndsWith(".");
        }
    }
