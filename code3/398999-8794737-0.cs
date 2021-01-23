      protected override void OnActionExecuting(ActionExecutingContext filterContext)
      {
         System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
         string[] a = User.Identity.Name.Split('\\');
         System.DirectoryServices.DirectoryEntry ADEntry = new System.DirectoryServices.DirectoryEntry("WinNT://" + a[0] + "/" + a[1]);
         ViewBag.Username = ADEntry.Properties["FullName"].Value.ToString();
         base.OnActionExecuting(filterContext);
      }
