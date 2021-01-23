    private DataTable myDataTable = null;
    private BindingSource myBindingSource = new BindingSource();
    // Column Name Constants
    private const string C_ITEM_INDEX = "Item_Index";      // CheckedListBox Item's Index
    private const string C_ITEM_TEXT = "Item_Text";        // Item's Text
    private const string C_ITEM_CHECKED = "Item_Checked";  // Item's Checked State
    private const string C_DATA_KEY = "Data_Key";          // Arbitrary Key Value for Relating Item to Other Data
        
    private void Startup()
    {
      // Create DataTable 
      // This DataTable has 4 Columns described by the constants above
      myDataTable = new DataTable();
      myDataTable.Columns.Add(new DataColumn(C_ITEM_INDEX, typeof(Int32)));
      myDataTable.Columns[C_ITEM_INDEX].DefaultValue = 0;
      myDataTable.Columns.Add(new DataColumn(C_ITEM_TEXT, typeof(string)));
      myDataTable.Columns[C_ITEM_TEXT].DefaultValue = "";
      
      // I personally like Integer 1=true, 0=false values.  typeof(bool) will also work.
      myDataTable.Columns.Add(new DataColumn(C_ITEM_CHECKED, typeof(Int32)));
      myDataTable.Columns[C_ITEM_CHECKED].DefaultValue = 0;
      
      // Other columns can be included in the DataTable
      myDataTable.Columns.Add(new DataColumn(C_DATA_KEY, typeof(Int32)));
      myDataTable.Columns[C_DATA_KEY].DefaultValue = 0;     
      myDataTable.AcceptChanges();
      // Bind the DataTable's DefaultView to the CheckedListBox
      myBindingSource.DataSource = myDataTable.DefaultView;
      this.myCheckedListBox.DataSource = myBindingSource;
      
      // Set the DisplayMember to the DataColumn you want displayed as the CheckedListBox Items's Text
      this.myCheckedListBox.DisplayMember = C_ITEM_TEXT;
      
      // Set the ValueMember to the Data.  Note:  The ValueMember is not displayed and is Not the CheckBox value.
      this.myCheckedListBox.ValueMember = C_DATA_KEY;
      
      // Hookup Event Handler for the CheckedListBox.Format Event.  
      /// * The Format event enables us to just in time update the CheckBoxes with the values in the DataTable
      this.myCheckedListBox.Format += myCheckedListBox_Format;
      
      // Hookup Event Handler for the CheckedListBox.ItemCheck Event.
      /// * The ItemCheck event enables us to just in time update the DataTable with the values from the Item CheckBoxes
      this.myCheckedListBox.ItemCheck += myCheckedListBox_ItemCheck;
    }
    
    void myCheckedListBox_Format(object sender, ListControlConvertEventArgs e)
    {
      /// * The Format event enables us to just in time update the CheckBoxes with the values in the DataTable
      // Retrieve the Index of the Item in the CheckedListBox by finding the DataRowView in the BindingSource
      //   Note:  Use a column with unique values for the BindingSource.Find() function
      int listindex = myBindingSource.Find(C_ITEM_INDEX, ((DataRowView)e.ListItem)[C_ITEM_INDEX]);
      
      // The argument, e.ListItem, is the current DataRowView in the DataTable's DefaultView
      // Check to see if the checkbox value is different from the data
      if (((CheckedListBox)sender).GetItemChecked(listindex) !=  Convert.ToBoolean(((DataRowView)e.ListItem)[C_ITEM_CHECKED]))
      {
        // Set the CheckList Item's CheckState to match the data
        ((CheckedListBox)sender).SetItemChecked(listindex, Convert.ToBoolean(((DataRowView)e.ListItem)[C_ITEM_CHECKED]));
      }
    }
   
    
    void myCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      /// * The ItemCheck event enables us to just in time update the DataTable with the values from the Item CheckBoxes
      // Update the data with the new CheckState value.  
      if (e.NewValue == CheckState.Checked)
      {
        myDataTable.DefaultView[e.Index][C_ITEM_CHECKED] = 1;
      }
      else
      {
        myDataTable.DefaultView[e.Index][C_ITEM_CHECKED] = 0;
      }
      // Update other data values too if you need to.
    }
