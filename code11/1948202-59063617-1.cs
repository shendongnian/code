public class Roles
{
    public Roles()
    {   
        modules = new List<Dictionary<string, List<string>>>();
    }
    public List<Dictionary<string, List<string>>> modules { get; set; }
}
/*Index*/
public ActionResult Index()
{
	var oRoles = new Roles(); 	
	var userRolePermissionsAndModulesList =  userRolePermissionManager.GetAllUserRolePermissionsAndModules(userId);
	
	foreach (var module in userRolePermissionsAndModulesList)
	{ 
		var objPermissionWithModules = new Dictionary<string, List<string>>();
		var permission = new List<string> { };
		if (module.CanCreate)
		permission.Add("Create");
		if (module.CanDelete)
		permission.Add("Delete");
		if (module.CanEdit)
		permission.Add("Update");
		if (module.CanView)
		permission.Add("View");
		objPermissionWithModules.Add(module.ModuleName, permission);
		oRoles.modules.Add(objPermissionWithModules);
	} 
	
	var json = Newtonsoft.Json.JsonConvert.SerializeObject(oRoles);
    return View(json);
}
> Please compare your output :
{
   "modules":[
      {
         "Page-Profile":[
            "Edit",
            "View",
            "Delete"
         ]
      },
      {
         "user":[
            "Edit",
            "View",
            "Delete",
            "Update"
         ]
      }
   ]
}
