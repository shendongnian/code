    public bool ValidateSocialSecNumber(string socialSecNumber)
    {
        //Accepts only 10 digits, no more no less. (Like Mike's answer)
        Regex pattern = new Regex(@"(?<!\d)\d{10}(?!\d)");
        if(pattern.isMatch(socialSecNumber))
        {
            //Do something
            return true;
        }
        else
        {
            return false;
        }
    }
