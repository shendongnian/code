    using (var ctxAdmin = new MemberDataContext(ConfigurationManager.ConnectionStrings[Constants.CONFIG_KEY_MEMBER_CONNECTION_STRING].ToString()))
    {
        var model = (from ba in ctxAdmin.Business_Analysis
                     where ba.User_Guid == userID
                     select new BusinessAnalysisViewModel
                     {
                         UserGuid = ba.User_Guid,
                         CreateDate = ba.CreateDate,
                         UpdateDate = ba.UpdateDate,
                         QuestionResponseIds = ba.QuestionResponseIds
                     });
        return model;
    }
