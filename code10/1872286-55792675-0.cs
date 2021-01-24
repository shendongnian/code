    for(int item = 0; item < Model.Count(); item++)
        {
            @Html.DisplayFor(m => m[item].ApplicationUser.Email);
            @Html.DisplayFor(m => m[item].ApplicationUser.Name);
            @Html.DisplayFor(m => m[item].ApplicationUser.FName);
            @Html.DisplayFor(m => m[item].ApplicationUser.Mobile);
            @Html.HiddenFor(m => m[item].UserId);
           @Html.CheckBox("selectuser", new { id = String.Format("id{0}", item), value = Model[item].UserId });
        }
