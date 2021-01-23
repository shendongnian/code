    public bool ValidateMail(string mailAdress)
    {
        if (String.IsNullOrEmpty(mailAdress))
        {
            ShowError("please enter email id!!");
            return false;
        }
        //The regular expression matches at:
        //[anything]-@-[anything except "."]-.-[2 or 3 chars after the "."]
        else if (!Regex.Match(mailAdress, @".+\@[^\.]+\..{2,3}")
                                .Length == mailAdress.Length)
        {
            ShowError("please enter correct email id!");
            return false;
        }
        return true
    }
