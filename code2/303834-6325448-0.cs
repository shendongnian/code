    AspNetHostingPermissionLevel GetCurrentTrustLevel() {
      foreach (AspNetHostingPermissionLevel trustLevel in
          new AspNetHostingPermissionLevel [] {
            AspNetHostingPermissionLevel.Unrestricted,
            AspNetHostingPermissionLevel.High,
            AspNetHostingPermissionLevel.Medium,
            AspNetHostingPermissionLevel.Low,
            AspNetHostingPermissionLevel.Minimal 
          } ) {
        try {
          new AspNetHostingPermission(trustLevel).Demand();
        }
        catch (System.Security.SecurityException ) {
          continue;
        }
     
        return trustLevel;
       }
    
       return AspNetHostingPermissionLevel.None;
    }
