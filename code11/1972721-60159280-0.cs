    if (GetOrPost == "GET")
     {
        if (actionName == "add" || actionName == "index" || actionName == "create" || actionName == "edit" || actionName == "delete" || actionName == "multiviewindex")
        {
          ViewBag.Add = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsAdd)).FirstOrDefault();
          ViewBag.Read = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsRead)).FirstOrDefault();
          ViewBag.Create = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsCreate)).FirstOrDefault();
          ViewBag.Edit = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsUpdate)).FirstOrDefault();
          ViewBag.Delete = menuaccess.Where(i => i.MenuURL == controllerName).Select(i => (i.IsDelete)).FirstOrDefault();
        }
      }
