    @{var selectList = new SelectList(db.PartyRoles.OrderBy(c => c.Role), 
                                     "Role", "Role",Model.PartyRoleID);} 
    /*pass the db.PartyRoles.OrderBy(c => c.Role) in view bag inside controller,
    it's cleaner*/
    @using (Html.BeginCollectionItem("Roles"))
    {
      @Html.EditorFor(model => model.TemplateID)
      @Html.DropDownList(model => model.PartyRoleID, selectList)
      @Html.EditorFor(model => model.DisplayName)
    }
