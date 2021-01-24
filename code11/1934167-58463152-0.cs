    @foreach (var item in Model) 
    {
        // if item.RaisedBy is current user
        if (item.RaisedBy == User.Identity.Name)
        { 
            // if current user is in "admin" role
            if(User.IsInRole("Admin"))
            {
            }
        }
    }
