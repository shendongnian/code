    public void ThenICanSeeTheFunctionlitiesForNONtransitionUserAsClnician() 
    {
      AssertMenuListItems(ObjectRepository.phPage.GetMenuList());
    }
    private void AssertMenuListItems(TypeOfGetMenuList items) 
    {
      Assert.IsTrue(items.Contains("Show menu"));
      Assert.IsTrue(items.Contains("Patient Summary"));
      Assert.IsTrue(items.Contains("Patient Encounter"));
    }
