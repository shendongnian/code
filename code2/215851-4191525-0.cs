protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)    
{   
   // Fill DropDownList3 data source and bind it again to restore all the items
   FillDataSource(); // This method gets all the data from DropDownList3
   DropDownList3.DataBind();
     
   if (DropDownList2.SelectedItem.Text == "Stamp")
   {
        DropDownList3.Items.Remove(DropDownList3.Items.FindByText("STA"));
        DropDownList3.Items.Remove(DropDownList3.Items.FindByText("STM"));        
   }
   ...
