     @Html.DropDownListFor(m => m.Month, 
    Model.MonthsList.Select(
            t => new SelectListItem {
                     Text = t.Name,
                     Value = t.Value,
                     Selected = t.Value == Model.Month,
            },
    
     Model.Month.ToString(), new { @disabled = "disabled" })
