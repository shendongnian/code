    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if (e.CommandName == "Select")
        {
            //Convert the row index stored in the CommandArgument
            //property to an Integer.
            LoadData(Convert.ToInt32(e.CommandArgument));
        }
    }
    private void LoadData(int? rowNumber = null)
    {
        //if rowNumber is null use GridView1.SelectedIndex
        var index = rowNumber ?? GridView1.SelectedIndex;
        //instead of the ?? operator you can write a simple if
        var index = -1;
        if (rowNumber == null)
            index = GridView1.SelectedIndex;
        else
            index = rowNumber.Value; //Access the value property of the nullable int
        if (index == -1)
            return; //index is invalid so exit the method
        // Retrieve the row that contains the button clicked 
        // by the user from the Rows collection.
        GridViewRow row = GridView1.Rows[index];
    
        //Populate the input box with the value of selected row.
        GridViewRow gr = GridView1.Rows[index];
        TextBox1.Text = gr.Cells[2].Text;
        //your code would add new Items to your DropDownList everytime this method gets called
        //DropDownList1.Items.Add(gr.Cells[3].Text.ToString());
        //DropDownList2.Items.Add(gr.Cells[4].Text.ToString());
        //instead use SelectedItem property of the DropDownList, didn't know why you call .ToString() on the Text property, seemed redundant so I removed it
        DropDownList1.SelectedItem = gr.Cells[3].Text;
        DropDownList2.SelectedItem = gr.Cells[4].Text;
        TextBox4.Text = gr.Cells[5].Text;
        TextBox5.Text = gr.Cells[6].Text;
        TextBox6.Text = gr.Cells[1].Text;
    }
