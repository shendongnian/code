    // create a list
    List<MyDataObject> myDataObjects = CreateTestData();
    
    // bind it
    listBox1.ItemSource = myDataObjects;
    
    ...
    
    // in your click handler
    private void btnDeleteDashboard_Click(object sender, EventArgs args)
    {
      // cast the sender to a button
      Button button = sender as Button;
    
      // find the item that is the datacontext for this button
      MyDataObject dataObject = button.DataContent as MyDataObject;
    
      // get the index
      int index = myDataObjects.IndexOf(dataObject);
    }
