    List<Email> emails = new List<Email>();
    using (var myketDB = new MyketReadOnlyDb())
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            emails = myketDB.AppDevelopers
                .Where(n => n.RealName.Contains(name))
                .Select(e => e.Email).ToList();
        }
    }
    // original outer using is now after the above
