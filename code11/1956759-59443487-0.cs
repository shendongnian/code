    @using (Html.BeginForm("SaveData", "Home", FormMethod.Post, new { id = "saveForm" }))
    {
        @Html.AntiForgeryToken()
    @Html.HiddenFor(m => m.SearchId)
    <ul>
        @if (Model?.UserDepartments != null)
        {
            
            for (int i = 0; i < Model.UserDepartments.Count(); i++)
            {
               
                @Html.CheckBoxFor(x => x.UserDepartments[i].IsChecked)
                @Html.DisplayFor(x => x.UserDepartments[i].DepName)
                @Html.HiddenFor(x => x.UserDepartments[i].DepId)
            }
        }
    </ul>
    <ul>
        @if (Model?.UserPermissions != null)
        {
       
            for (int i = 0; i < Model.UserPermissions.Count(); i++)
            {
               
                @Html.CheckBoxFor(x => x.UserPermissions[i].IsChecked_)
                @Html.DisplayFor(x => x.UserPermissions[i].PerName)
                @Html.HiddenFor(x => x.UserPermissions[i].PerId)
            }
        }
    </ul>
    <input type="submit" value="Save" class="btn btn-default" />
    }
