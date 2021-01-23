    internal class RESTAuthorizationPolicy : IAuthorizationPolicy
    {
      public RESTAuthorizationPolicy()
      {
        Id = Guid.NewGuid().ToString();
        Issuer = ClaimSet.System;
      }
    
      public bool Evaluate(EvaluationContext evaluationContext, ref object state)
      {
        const String HttpRequestKey = "httpRequest";
        const String UsernameHeaderKey = "x-ms-credentials-username";
        const String PasswordHeaderKey = "x-ms-credentials-password";
        const String IdentitiesKey = "Identities";
        const String PrincipalKey = "Principal";
    
        // Check if the properties of the context has the identities list 
        if (evaluationContext.Properties.Count > 0 ||
          evaluationContext.Properties.ContainsKey(IdentitiesKey) ||
          !OperationContext.Current.IncomingMessageProperties.ContainsKey(HttpRequestKey))
          return false;
    
        // get http request
        var httpRequest = (HttpRequestMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpRequestKey];
    
        // extract credentials
        var username = httpRequest.Headers[UsernameHeaderKey];
        var password = httpRequest.Headers[PasswordHeaderKey];
    
        // verify credentials complete
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
          return false;
    
        // Get or create the identities list 
        if (!evaluationContext.Properties.ContainsKey(IdentitiesKey))
          evaluationContext.Properties[IdentitiesKey] = new List<IIdentity>();
        var identities = (List<IIdentity>) evaluationContext.Properties[IdentitiesKey];
    
        // lookup user
        using (var con = ServiceLocator.Current.GetInstance<IDbConnection>())
        {
          using (var userDao = ServiceLocator.Current.GetDao<IUserDao>(con))
          {
            var user = userDao.GetUserByUsernamePassword(username, password);
            
            ...
