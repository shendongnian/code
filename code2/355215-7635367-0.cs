    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        //Loop throug all Pages
        for (int i = 0; i < ASPxGridView1.PageCount; i++)
        {
            //Select current page
            ASPxGridView1.PageIndex = i;
    
            //Loop through all rows inisde the page
            for (int J = 0; J < ASPxGridView1.SettingsPager.PageSize; J++)
            {
                 //Get currnt TextBox
                 DevExpress.Web.ASPxEditors.ASPxTextBox txtbox = 
                 ASPxGridView1.FindRowCellTemplateControl(J,
                 (DevExpress.Web.ASPxGridView.GridViewDataColumn)ASPxGridView1.Columns["Capacitiy"],
                 "txtCapacity") as DevExpress.Web.ASPxEditors.ASPxTextBox;
    
                 //Do your logic here
             }
        }
    }
