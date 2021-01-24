    int GetUserLanguageCode(IPluginExecutionContext context) 
    {
      var userSettingsQuery = new QueryExpression("usersettings");
      userSettingsQuery.ColumnSet.AddColumns("uilanguageid", "systemuserid");
      userSettingsQuery.Criteria.AddCondition("systemuserid", 
        ConditionOperator.Equal, 
        context.InitiatingUserId);
      var userSettings = this.orgService.RetrieveMultiple(userSettingsQuery);
      return (int)userSettings.Entities[0]["uilanguageid"];
    }
