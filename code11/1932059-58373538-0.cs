    lvEmployees1.View = View.Details;
    lvEmployees1.GridLines = true;
    lvEmployees1.Items.Clear();
    lvEmployees2.View = View.Details;
    lvEmployees2.GridLines = true;
    lvEmployees2.Items.Clear();
    List<Employees> data = database.LoadEmployees();
    int half = data.Count / 2;
    for (int i = 0; i < data.Count; i++)
    {
        // Define the list items
        ListViewItem emp = new ListViewItem(data[i].Abbreviation);
        emp.SubItems.Add(data[i].Name);
        emp.SubItems.Add(data[i].Status);
        if (i <= half)    lvEmployees1.Items.Add(emp);
        else              lvEmployees2.Items.Add(emp);
    }
