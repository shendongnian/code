     public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();  
            var url = Url.Action("Index", "Web"); 
            HttpResponse.RemoveOutputCacheItem(url);           
            return RedirectToAction("Index", "Web");
        }
