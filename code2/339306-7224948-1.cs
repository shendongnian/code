    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDropDownLists();
    }
    private void LoadDropDownLists()
    {
        //Dummy data, you would pull your categories/attributes from whichever datasource
        //you are using
        var categories = new[]{
            new { Name = "Category 1", Id = 1, Attributes = new string[]{"GA", "FA", "RA"} },
            new { Name = "Category 2", Id = 2, Attributes = new string[]{"GA", "NA"} }
        };
        //Loop through the categories, load the dropdown
        foreach (var category in categories)
        {
            if (!IsPostBack)
                categoryDropDownList.Items.Add(new ListItem(category.Name, category.Id.ToString()));
            //For each attribute create a drop down and populate with data as required
            foreach (var attribute in category.Attributes)
            {
                string dropDownListId = string.Format("dropDown{0}", attribute);
                if (!DropDownListExists(dropDownListId))
                {
                    DropDownList dropDownList = new DropDownList();
                    dropDownList.ID = dropDownListId;
                    dropDownList.Visible = false;
                    dropDownList.Items.Add(new ListItem(attribute));
                    dropDownContainer.Controls.Add(dropDownList);
                }
            }
        }
    }
    private bool DropDownListExists(string id)
    {
        DropDownList dropDownList = (DropDownList)dropDownContainer.FindControl(id);
        return dropDownList != null;
    }
    protected void categoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Reset all visible dropdowns
        HideAllDropDownLists();
        //Get the selected category
        string selectedItem = categoryDropDownList.SelectedItem.Value;
        switch (selectedItem)
        {
            case "1":
                {
                    //Here you would connect to db and pull correct attributes
                    //then set the visible dropdowns as required
                    SetDropDownVisibility("GA");
                    SetDropDownVisibility("FA");
                    SetDropDownVisibility("RA");
                } break;
            case "2":
                {
                    SetDropDownVisibility("GA");
                    SetDropDownVisibility("NA");
                } break;
        }
    }
    private void SetDropDownVisibility(string id)
    {
        DropDownList dropDownList = (DropDownList)dropDownContainer.FindControl(string.Format("dropDown{0}", id));
        dropDownList.Visible = true;
    }
    private void HideAllDropDownLists()
    {
        foreach (Control control in dropDownContainer.Controls)
        {
            control.Visible = false;
        }
    }
