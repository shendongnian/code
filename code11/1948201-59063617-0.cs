public class Roles
{
	public Roles()
	{	
		modules = new List<Dictionary<string, List<string>>>();
	}
	
    public List<Dictionary<string, List<string>>> modules { get; set; }
}
public ActionResult Index()
{
	var oRoles = new Roles(); 
	var odt = new Dictionary<string, List<string>>();
		odt.Add("Page-Profile", new List<string> { "Edit", "View", "Delete" });
	
	oRoles.modules.Add(odt); //this can be replaced by some loop 
	
	odt = new Dictionary<string, List<string>>();
	odt.Add("user", new List<string> { "Edit", "View", "Delete", "Update" });
	
	oRoles.modules.Add(odt);
	
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
