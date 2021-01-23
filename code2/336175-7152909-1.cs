        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = TaskGridView.Rows[e.RowIndex];
            GridView1.EditIndex = -1;
            TextBox txtCurrency = (TextBox)(row.Cells[2].Controls[0]);
            if (!Page.IsPostBack)
            {
                FillTravelers();
            }
            //... Rest of the code
        }
