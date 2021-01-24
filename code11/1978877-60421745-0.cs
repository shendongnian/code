    public void ThenICanSeeTheFunctionlitiesForNONtransitionUserAsClnician()
    {
        var menuItems = ObjectRepository.phPage.GetMenuList();
        Assert.IsTrue(menuItems.Contains("Show menu") && menuItems.Contains("Patient Summary") && menuItems.Contains("Patient Encounter"));
    }
