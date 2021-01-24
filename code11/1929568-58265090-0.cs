    protected void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if (e.CommandName == "Select")
        {
            ///<summary>
            ///Convert the row index stored in the CommandArgument
            ///property to an Integer.
            ///</summary>
            LoadData(Convert.ToInt32(e.CommandArgument));
        }
    }
    private void LoadData(int? rowNumber = null)
    {
        var index = rowNumber ?? GridView1.SelectedRow.Index;
    
        ///<summary>
        /// Retrieve the row that contains the button clicked 
        /// by the user from the Rows collection.
        ///</summary>
        GridViewRow row = GridView1.Rows[index];
    
        ///<summary> Populate the input box with the value of selected row.</summary>
        GridViewRow gr = GridView1.Rows[index];
        TextBox1.Text = gr.Cells[2].Text;
        DropDownList1.Items.Add(gr.Cells[3].Text.ToString());
        DropDownList2.Items.Add(gr.Cells[4].Text.ToString());
        TextBox4.Text = gr.Cells[5].Text;
        TextBox5.Text = gr.Cells[6].Text;
        TextBox6.Text = gr.Cells[1].Text;
    }
