    protected void gvTest_RowUpdating(object sender, GridViewUpdateEventArgs e) {
      // Convenient access to the row index that was selected
      int theRowIndex = e.RowIndex;
      GridViewRow gvr = gvTest.Rows[e.RowIndex];
    
      // Now its just a matter of tracking down your various controls in the row and doing 
      // whatever you need to with them
      TextBox someTxtBox = (TextBox)gvr.FindControl("theTextBoxID");
      DropDownList someDDL = (DropDownList)gvr.FindControl("theDDL_ID");
    
      // Perhaps some business class that you have setup to take the value of the textbox
      // and insert it into a table
      MyDoSomethingClass foo = new MyDoSomethingClass {
        FirstName = someTxtBox.Text,
        Age = someDDL.SelectedItem.Value
      };
      foo.InsertPerson();
    }
