    public bool IsInRole(string sRoleToFind) {
       foreach (string sRole in this.Roles) {
          if (sRoleToFind.Equals(sRole, StringComparison.InvariantCultureIgnoreCase) {
             return true;
          }
       }
       return false;
    }
