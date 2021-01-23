    using ImpromptuInterface.Dynamic;
    using System.Dynamic;
    ...
    public IEnumerable<dynamic> GetMenuItems()
       {
           var @new = Builder.New<ExpandoObject>();
           dynamic menuItems = new[]{
					   @new.Object(Title:"Home"),
					   @new.Object(Title:"Categories")
					};
	       return menuItems; 
       }
 
