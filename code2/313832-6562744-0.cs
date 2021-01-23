     protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                TextBox textBox = e.Row.FindControl("TextBoxID") as TextBox;
    
                if(<<Your condition>>)
                {
                    textBox.Enabled = false;
                }
            }
