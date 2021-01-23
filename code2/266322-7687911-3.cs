    var page = HttpContext.Current.Handler as Page;
    string text = "<table><tr><td>Testing!!!</td></tr></table>";
    var systemWebAssembly = System.Reflection.Assembly.GetAssembly(typeof(Page));
    var virtualPathType = systemWebAssembly.GetTypes().Where(t => t.Name == "VirtualPath").FirstOrDefault(); // Type.GetType("System.Web.VirtualPath");
    var createMethod = virtualPathType.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).Where(m => m.Name == "Create" && m.GetParameters().Length == 1).FirstOrDefault();
    object virtualPath = createMethod.Invoke(null, new object[]
    { 
        page.AppRelativeVirtualPath 
    });
    var template = (ITemplate)typeof(TemplateParser).GetMethod("ParseTemplate", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).Invoke(null, new object[]{text, virtualPath, true});
