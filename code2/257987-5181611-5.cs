    var sbProducts = new StringBuilder();
    var selectedCat = Request.QueryString["categoryid"];
    if(!string.IsNullOrWhitespace(selectedCat))
    {
        var selectedCatId = Int32.Parse(selectedCat);
        var products = __account.GetSpecificCategory(selectedCatId);
        for(int j = 0; j < products.Rows.Count; j++)
        {
             // ... do product listing stuff here
             // sbProducts.Append(...);
        }
    }
    else
    {
        sbProducts.AppendLine("Invalid Category Id Selected!");
    }
    active_selected_products.Text = sbProducts.ToString();
