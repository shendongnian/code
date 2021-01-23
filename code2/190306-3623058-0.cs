    private IEnumerable GetSessions()
    {
        using (var entities = new DbEntities(Properties.Settings.Default.UserConnectionString))
        {
            entities.CommandTimeout = 7200;
            var sessions = from t in entities.TableName
                            where t.UserSession.Id == _id && t.Parent == 0
                            group t by new { t.UserSession, t.UserSession.SessionId } into sessionGroup
                            select new
                            {
                                Id = sessionGroup.Key.UserSession,                                   
                                Session = sessionGroup.Key.SessionId                                   
                            };
            foreach(var sess in sessions.Where(x => x.Time > 0.00))
              yield return sess;
        }
    }
