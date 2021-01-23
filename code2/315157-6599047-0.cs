    <%= Html.Serialize("User",Model) %>
    [HttpPost]   
    public ActionResult Register([DeserializeAttribute] User user, FormCollection userForm)
    {
    }
