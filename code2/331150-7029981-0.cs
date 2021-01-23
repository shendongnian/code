    industry = Request.QueryString["ind"].ToString();
    industrydropdown.SelectedValue = industry;
    
    fillCatDropDownList(); // Fill the category Dropdown before selection
    category = Request.QueryString["cat"].ToString();
    CatDropDown.SelectedValue = category
    private void fillCatDropDownList()
    {
    string value = industrydropdown.SelectedValue;
        switch (value)
        {
            case "Ind1":
                CatDropDown.Items.Clear();
                CatDropDown.Items.Add("Categories for Ind1");
                break;
            case "Ind2":
                CatDropDown.Items.Clear();
                CatDropDown.Items.Add("Categories for Ind2");
                break;
        }
     }
