    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
    for (int i = 0; i < 1000; i++)
    {
        collection.Add(string.Format("Item {0}", i.ToString()));
    }
    comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
    comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    comboBox1.AutoCompleteCustomSource = collection;
