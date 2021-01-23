    public GetSchemeCode()
    {
            DistCodeDropDownList.AutoPostBack = true;
            DistCodeDropDownList.SelectedIndexChanged += new EventHandler(DistCodeDropDownList_SelectedIndexChanged);
            // TODO: Hook up the other DropDownLists here. as well
    }
        void DistCodeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodeOutputLabel.Text = GetNewSchemeCode();
        }
