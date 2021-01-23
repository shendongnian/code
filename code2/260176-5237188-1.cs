    var usernames = ((from e in db.EmailAlerts select e.UserName).Union
                    (from t in db.TextAlerts select t.UserName)).Distinct();
    var result =
        from e in EmailAlerts
        from t in TextAlerts
        where (usernames.Contains(e.Username) || usernames.Contains(t.Username))
              && (e.Type == [value] || t.Type ==  && e.Status == 0 /* put other conditions here */)
        select new 
        {
            Username = e.Username,
            ActiveType1Email = e.ActiveType1Email,
            /*
             ... and so on
            */
        }
    
        // and then go trough the result set which is IEnumarable<T> and use it for what you need
        foreach(var a in result)
        { // etc. }
