     public Session CreateSession()
        {
            var session = new Session();
            _accountSessionDataModel.Sessions.Add(session);
            _accountSessionDataModel.SaveChanges();
         }
