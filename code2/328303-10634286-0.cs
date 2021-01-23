    public static void CreateAccount(string accountName, string accountType)
    {
       ////Create DynamicEntity
       Entity accountToCreate = new Entity();
       accountToCreate.LogicalName = "account";
       accountToCreate.Attributes = attributes;
       //Append properties
       accountToCreate.Attributes.Add("name", accountName ?? "" );
       accountToCreate.Attributes.Add("new_accounttype", new OptionSetValue(100000003);
        
       try
       {
         service.Create(accountToCreate);
       }
    }
