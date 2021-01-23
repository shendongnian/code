      User user = new User();
      string ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
      string city = string.Empty;
      string region = string.Empty;
      string country = string.Empty;
      double? latitude = -1.00;
      double? longitude = -1.00;
      LocationTools.GetLocationFromIP(ipAddress, out city, out region, out country, out latitude, out longitude);
      user.IPAddress = ipAddress; 
      // other code to fill the other fields of User
      return user;
    }
