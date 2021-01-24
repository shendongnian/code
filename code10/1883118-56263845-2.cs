    public ActionResult Step(FormCollection collection, HttpPostedFileBase file) {
        //HttpPostedFileBase file; //this comes from you controller argument
        var directory = "~/Uploads/";
        //this if statement can be optional
        if(!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(directory)))
        { 
            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(directory));
            var virtualPath = directory + "/" + <your file name here>;
            var filePath = System.Web.HttpContext.Current.Server.MapPath(virtualPath);
            //if the file exists already, delete and replace it with the new one
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            file.SaveAs(filePath);
         }
        else {
            //do as above without the create directory
        }
    }
