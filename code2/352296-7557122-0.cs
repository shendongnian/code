      void GridView1_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
      {
    
        // Indicate whether the update operation succeeded.
        if(e.Exception == null)
        {
          int index = GridView1.EditIndex;
          GridViewRow row = GridView1.Rows(index);
          //example to pull the data from a cell to send it to your function
          SendEmail(row.Cells(0).Text);
          
          Message.Text = "Row updated successfully. Email Sent!";
        }
        else
        {
          e.ExceptionHandled = true;
          Message.Text = "An error occurred while attempting to update the row. No email sent.";
        }
    
      }
