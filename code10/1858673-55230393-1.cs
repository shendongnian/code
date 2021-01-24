    // Adding new client to TreeView
    TreeViewItem item = new TreeViewItem();
    item.Header = entry.Key;
    foreach (var date in entry.Value.ToArray())
    {
        var child = new TreeViewItem();
        child.Header = date;
        child.MouseDoubleClick += TreeViewItem_MouseDoubleClick; // Only subscribe to the child
        item.Items.Add(child);
    }
    try
    {
        Arbol_Clientes.Items.Add(item);
    }
    catch (Exception error)
    {
        Console.WriteLine("ERROR: " + error.ToString());
    }
