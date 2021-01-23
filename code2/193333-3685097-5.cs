    GridView newGrid = new GridView();
    TemplateField field = new TemplateField();
    field.HeaderText = "columnName";
    field.ItemTemplate = // some item template
    field.EditItemTemplate = new AddTemplateToGridView("yourField");
    newGrid.Columns.Add(field);
