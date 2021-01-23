    void AuthorsGridView_RowUpdating (Object sender, GridViewUpdateEventArgs e)
      {
        // The GridView control does not automatically extract updated values 
        // from TemplateField column fields. These values must be added manually 
        // to the NewValues dictionary.
    
        // Get the GridViewRow object that represents the row being edited
        // from the Rows collection of the GridView control.
        int index = AuthorsGridView.EditIndex;
        GridViewRow row = AuthorsGridView.Rows[index];
    
        // Get the controls that contain the updated values. In this
        // example, the updated values are contained in the TextBox 
        // controls declared in the edit item templates of each TemplateField 
        // column fields in the GridView control.
        TextBox lastName = (TextBox)row.FindControl("LastNameTextBox");
        TextBox firstName = (TextBox)row.FindControl("FirstNameTextBox");
    
       
      }
