    var results = new List<UserSummaryDto>();
    using (var ctx = new 
        UsersDataContext(ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString))
    {
            try
            {
                results = ctx.SearchPhoneList(value, maxRows)
                             .Select(user => user.ToDto())
                             .ToList();
                break;
            }
            catch (SqlException)
            {
                try
                {
                    results = ctx.SearchPhoneList(value, maxRows)
                             .Select(user => user.ToDto())
                             .ToList();
                    break;
                }
                catch (SqlException)
                {
                    // set return value, or indicate failure to user however
                }
            }
        }
    }
    return results;
