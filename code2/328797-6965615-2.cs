        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridView1.Rows[index];
            ImageButton button = (ImageButton)e.CommandSource;
            switch (e.CommandName)
            {
                case "Add":
                    // Use selectedRow to add your rows       
                    button.ImageUrl = "~/images/down.gif";
                    button.CommandName = "Remove";
                    break;
                case "Remove":
                    // Use selectedRow to remove your rows
                    button.ImageUrl = "~/images/left.gif";
                    button.CommandName = "Add";
                    break;
            }
        }
