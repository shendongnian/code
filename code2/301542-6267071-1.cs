    DropDownList ddl = new DropDownList();
    ddl.ID = "ddl";
    ddl.Items.Add(new ListItem("Text", "Value")); // add list items
    TableCell c2 = new TableCell();
    c2.Controls.Add(ddl);
    r.Cells.Add(c2);
    Table1.Rows.Add(r);
