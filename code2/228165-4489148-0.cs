    listbox.DisplayMember = "username";
    listbox.ValueMember = "userid";
    var item1 = new MyType { username = "user1", userid = "id1" }; // Create an item for the list
    
    listbox.Items.Add(item1); // Add the item
    listbox.SelectedIndex = 0; // Selects the first item
