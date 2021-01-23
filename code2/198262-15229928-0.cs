    var tx = TextEditMoveTo.MaskBox;
    
    AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
    customSource.Add("Yes");
    customSource.Add("You");
    customSource.Add("Can");
    tx.AutoCompleteSource = AutoCompleteSource.CustomSource;
    tx.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    tx.AutoCompleteCustomSource = customSource;
