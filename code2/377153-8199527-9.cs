    protected void MyDropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyDropDownList l = (sender as MyDropDownList);
            if (l != null)
            {
                string selectedCustomProperty = l.SelectedCustomProperty;
                //Do something cool with this selectedCustomProperty 
            }
        }
