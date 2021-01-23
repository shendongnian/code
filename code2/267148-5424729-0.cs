        Settings secSettings = new Settings();
        secSettings.Add(new SettingNames.App1.Screen1.MaxBillAmountToConsolidate(), 50m);
        secSettings.Add(new SettingNames.App2.SingleSetting(), new DateTime(2010, 11, 25));
        secSettings.Add(new SettingNames.App1.Screen2.CanEditField2(), false);
        secSettings.Add(new SettingNames.App1.Screen2.CanEditField3(), true);
        int amount;
        if (secSettings.TryGetValue(new SettingNames.App1.Screen1.MaxBillAmountToConsolidate(), out amount))
        {
            Print(amount);
        }
        DateTime expiredDate;
        if (secSettings.TryGetValue(new SettingNames.App2.SingleSetting(), out expiredDate))
        {
            Print(expiredDate);
        }
        bool permission;
        if (secSettings.TryGetValue(new SettingNames.App1.Screen2.CanEditField2(), out permission))
        {
            Print(permission);
        }
        if (secSettings.TryGetValue(new SettingNames.App1.Screen2.CanEditField3(), out permission))
        {
            Print(permission);
        }
