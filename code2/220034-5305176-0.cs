    var items = cblLanguages.Items.Cast<ListItem>();
    // Selected Items
    var selectedItems = items.Where(li => li.Selected);
    // Item's containing 'C'
    var itemsWithC = items.Where(li => li.Text.Contains("C"));
    // Values between 2 and 5
    var itemsBetween2And5 = from li in items
                            let v = Convert.ToInt32(li.Value)
                            where 2 <= v && v <= 5
                            select li;
