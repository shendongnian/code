    // create the column (probably better done by the designer)
    DataGridViewComboBoxColumn categoryColumn = ...
    
    
    // bind it
    categoryColumn.DataSource = db.Categories.ToList();
    categoryColumn.DisplayMember = "catName";  // display category.catName
    categoryColumn.ValueMember = "id";         // use category.id as the identifier
    categoryColumn.DataPropertyName = "catId"; // bind the column to book.catId
