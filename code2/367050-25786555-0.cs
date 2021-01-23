    // Database operation, no soap client funny business here.
     var list = (
      from u in _db.Sessions
      where u.DeletedOn == null
      orderby x.CreatedOn descending
      select new
      {
       SessionId = u.UploadSessionId,
       FileName = u.FileName,
       CreatedBy = u.User.UserName,
       Partner = u.Company.Name,
       CreatedOn = u.CreatedOn,
      }).ToList();
    
    // From now on you are not in a database anymore, it's pure linq-to-objects. You can call the service.
    ServiceSoapClient service = new ServiceSoapClient();
    var dataSource = (from u in list select new {
     SessionId = u.SessionId,
     FileName = u.FileName,
     CreatedBy = u.CreatedBy,
     Partner = u.Partner,
     CreatedOn = u.CreatedOn,
     Visible = service.IsSessionProcessing(u.SessionId)
    }).ToList();
