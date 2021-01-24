    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = ddlTest.SelectedItem.Text;
            string selectedValue = ddlTest.SelectedItem.Value;
     
            //--- Show results in page.
            Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        }
