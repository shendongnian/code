    // Use flags you want
    var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
    // From the listbox containing list of classes names
    string name = listBox1.SelectedItem.ToString();
    // The listbox where to show properties of the selected class
    listBox2.Clear();
    foreach ( var property in Type.GetType(name).GetProperties(flags) )
      listBox2.Items.Add(property.Name);
