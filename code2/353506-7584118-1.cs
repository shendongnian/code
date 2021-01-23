    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
    for (int i = 0; i < 1000; i++)
    {
        string item = string.Format("Item {0}", i.ToString());
        collection.Add(item);
        comboBox1.Items.Add(item);
    }
    comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
    comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    comboBox1.AutoCompleteCustomSource = collection;
