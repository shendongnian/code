    // Setup listview appearance
    listView1.Columns.Clear();
    listView1.Columns.Add("").Width = -2;
    listView1.View = View.Details;
    listView1.HeaderStyle = ColumnHeaderStyle.None;
    // Add items
    listView1.Items.Add("Aber Aber aber");
    listView1.Items.Add("Kunde mit ID 1234 ist nicht in der Datenbank enthalten");
    listView1.Items.Add("Stackoverflow rulez");
