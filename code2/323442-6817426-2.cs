    var x = doc.Descendants.First();
    testPlan.Name= x.Attribute("name").ToStringValue();
    testPlan.DatabaseName = x.Attribute(DATABASE_ATTR).ToStringValue();
    testPlan.LoginUsername = x.Attribute(USERNAME_ATTR).ToStringValue();
    testPlan.LoginPassword = x.Attribute(PASSWORD_ATTR).ToStringValue();
    testPlan.ApplicationSource = x.Attribute(APPSOURCE_ATTR).ToStringValue();
