    <%= Html.CheckBox("IsResponseUnavailable", Model.IsResponseUnavailable, 
        new { onClick = "this.form.submit();" }) %>
    
    <%= Html.MyDropDownList(string.Format("Questions[{0}].Answer", i),  
        (IEnumerable<SelectListItem>)ViewData["Periods"], Model.Questions[i].Answer),
        new { onchange = "this.form.submit();" }) %>
