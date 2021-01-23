    public static bool isValidEmail(this string email)
    {
        string[] mail = email.Split(new string[] { "@" }, StringSplitOptions.None);
        if (mail.Length != 2)
            return false;
        //check part before ...@
        if (mail[0].Length < 1)
            return false;
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\-\.]+$");
        if (!regex.IsMatch(mail[0]))
            return false;
        //check part after @...
        string[] domain = mail[1].Split(new string[] { "." }, StringSplitOptions.None);
        if (domain.Length < 2)
            return false;
        regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9_\-]+$");
        foreach (string d in domain)
        {
            if (!regex.IsMatch(d))
                return false;
        }
        //get TLD
        if (domain[domain.Length - 1].Length < 2)
            return false;
        return true;
    }
