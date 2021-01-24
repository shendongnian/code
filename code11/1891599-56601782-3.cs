    @{
    	List<SelectListItem> listItems = new List<SelectListItem>();
    	foreach (var item in Model)
    	{
    		listItems.Add(new SelectListItem
    		{
    			Text = item.Text,
    			Value = item.Value,
    			Selected = item.Selected
    		});
    	}
    }
    @Html.DropDownList("idTipoCaso", listItems, "Nombre");
