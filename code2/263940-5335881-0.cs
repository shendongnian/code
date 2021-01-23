     ObjectGetOptions objectGetOptions = new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
     ManagementClass managementClass = new ManagementClass("root\\directory\\LDAP", "ads_user", objectGetOptions);
    
     foreach (PropertyData dataObject in managementClass.Properties)
     {
        Console.WriteLine(dataObject.Name);
     }
