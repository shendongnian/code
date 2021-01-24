    List < string > roleOptions = new List < string > () {
     "Administrator"
    };
    var payload = new JwtPayload {
     {
      "roles",
      roleOptions
     }
    };
    
        string key = "eyJjb21wYW5pZXMiOlt7IklkIjoxLCJDb2RlIjoiQzAxIiwiTmFtZSI6IkNvbXBhbnkgSSIsIkJyYW5jaGVzIjpudWxsLCJVc2VycyI6W3siSWQiOjEsIk5hbWUiOiJV";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var header = new JwtHeader(credentials);
        var secToken = new JwtSecurityToken(header, payload);
        var handler = new JwtSecurityTokenHandler();
        var tokenString1 = handler.WriteToken(secToken);
        _logger.Info(secToken.ToString());
        _logger.Info(tokenString1);
