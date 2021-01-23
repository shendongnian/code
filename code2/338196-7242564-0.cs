     protected void gvClients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            GridViewRow row = gvClients.Rows[e.RowIndex];
          
            if (ViewState["CitySelect"] != null)
            {
                e.NewValues.Remove("city");
                string tempCity = (string)ViewState["CitySelect"];
                e.NewValues.Add("city",tempCity);
                row.Cells[7].Text = (string)e.NewValues["city"];
            }
            else
                row.Cells[7].Text = (string)e.OldValues["city"];
        }
