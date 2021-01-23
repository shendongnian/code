    public IEnumerable<UserLink> UserLinks()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new UserLink
            {
                Name = "A",
                Url = "B.com",
                Something = "C",
                Parameters = 
                { 
                    new Parameter { Name = "X", Value = "Y" }, 
                    new Parameter { Name = "Z", ParameterValue = i.ToString() }
                }
            };
        }
    }
