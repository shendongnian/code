    using System.ComponentModel.DataAnnotations;
    // ...
	public class MyCustomZoo
	{
	    [Display(Name = "Cute Mouse")] 
	    public object CuteMouse;
	
	    [Display(Name = "Frightning Lion")] 
	    public int FrightningLion;
	}	
	public static string FieldDisplayName(FieldInfo field)
	{
		DisplayAttribute da = (DisplayAttribute)(field.GetCustomAttributes(typeof(DisplayAttribute), false)[0]);
		return da.Name;
	}
	
    // ...
	// c# identifier names, results in {"CuteMouse","FrightningLion"}	
	List<string> fieldNames = typeof(MyCustomZoo).GetFields().Select(field => field.Name).ToList();
	// "human readable" names, results in {"Cute Mouse","Frightning Lion"}	
	List<string> fieldDisplayNames = typeof(MyCustomZoo).GetFields().Select(field => FieldDisplayName(field)).ToList();
