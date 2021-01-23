    private void form1_Closing..
    {
        SaveList(_comboBoxLastEnteredValues);//Like(File.WriteAllLines(_comboBoxLastEnteredValues.ToArray(), _comboBoxSavedListPath);
    }
    
    private void form1_Load...
    {
        _comboBoxLastEnteredValues = LoadLastSavedList();//Like File.ReadAllLines(_comboBoxSavedListPath);
    }
