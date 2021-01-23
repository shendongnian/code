     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
     {
          if (e.CommandName == "Select")
          {
              int num = Convert.ToInt32(e.CommandArgument);
              instTextBox.Text = GridView1.Rows[num].Cells[1].Text;
              //Or you can also do dis
              //Set Label lblTest.text = "It Executes"; 
              //just to check if your code reaches here
          }
      }
