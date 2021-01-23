    using System.IO;
    using System.Web;
    
    var path = Path.Combine("~/Uploads", DataBaseName, REOID, "ExternalDocument");
    var fullPath = Server.MapPath(path);
