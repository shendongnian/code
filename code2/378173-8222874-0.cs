    var emails = input.Split(',');
    foreach (var email in emails.Select(ee => ee.Trim()))
    {
        if (!emailValidator.IsMatch(email))
        {
            // announce a bad email
        }
    }
