    @{
    	List<SelectListItem> listItems = new List<SelectListItem>();
    	foreach (var item in Model)
    	{
    		listItems.Add(new SelectListItem
    		{
    			Text = @Html.DisplayFor(modelItem => item.Text).ToString(),
    			Value = @Html.DisplayFor(modelItem => item.Value).ToString(),
    			Selected = Convert.ToBoolean(Html.DisplayFor(modelItem => item.Selected))
    		});
    	}
    	Html.DropDownList("idTipoCaso", listItems, "Nombre");
    }
