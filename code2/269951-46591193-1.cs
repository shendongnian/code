    using System.IO;   
    using System.Web.Mvc;
    
        namespace Extensions {
            public static class ControllerExtensions {
                public static string ResolveVirtualFolderPath(this Controller controller, string folder_name) => controller?.HttpContext?.Server?.MapPath(Path.Combine(controller?.HttpContext?.Request?.ApplicationPath, folder_name));                
        }
    }
