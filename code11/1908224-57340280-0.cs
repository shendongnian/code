      try
      {
       // Perform data insertion
       connection.Open();
       insertNewUser.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
       LabelMessage.Text = "Error at the catch: " + ex.ToString();
       PanelResultSection.Visible = true;
       PanelResultSection.CssClass = "alert-warning";
       return;
      }
      finally
      {
       // Close connection
       connection.Close();
      }
     // Send email and display link to login
     PanelResultSection.Visible = true;
     PanelResultSection.CssClass = "alert-success";
     LabelMessage.Text = "Success! " + newFName + " " + newLName + " has been added to " + theProfileGroupe + " group.";
    
      
     
