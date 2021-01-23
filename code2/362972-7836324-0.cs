    return (from t1 in db.BU
                from t2 in db.UserNames
                 .Where(t => (t.User_Username == t1.Username))
                from t3 in db.Logins
                .Where(t => (t.username == t1.Username))
                .OrderBy(u => u.timestamp).First()           // <--------- add this
                where myBusinessUnits.Contains(t1.BusinessUnit_ID)
                orderby (t2.Name) descending
                select new GlobalMyTeamDetailModel
                {
                     LastLogin = t3.timestamp,
                     Name = t2.Name
                });
