    [WebMethod]
    public static bool Save_Mapped_Role(object savedRole)
    {
       bool success = false;
       var serializer = new JavaScriptSerializer();
       SavedRole role = serializer.Deserialize<SavedRole>(savedRole);
   
       //Loop through the data like so
       int roleIndex = 0;
       string roleID = null;
       string roleName = null;
	
       foreach (var item in role.roleInfo) {
           roleIndex =  item.roleIndex;
           roleID = item.roleID;
           roleName = item.roleName;
		
           //Do more logic with captured data
       }
       return success; 
    }
