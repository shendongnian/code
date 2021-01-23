    Bind<string>()
        .ToMethod(ctx => 
        {
            var attr = (ConnectionStringAttribute)context.Request.Target.GetCustomAttributes(typeof(ConnectionStringAttribute), true).First();
            string settingName = string.IsNullOrEmpty(attr.SettingName) ? context.Request.Target.Name : attr.SettingName;
            return ConfigurationManager.ConnectionStrings[settingName].ConnectionString;
        })
        .WhenTargetHas<ConnectionStringAttribute>();
