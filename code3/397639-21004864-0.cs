    public static ComboBox FillDropDownList(Dictionary<String, String> dictionary, ComboBox dropDown, String selecione)
    {
        var d = new SortedDictionary<String, String>();
        d.Add("0", selecione);
        foreach (KeyValuePair<string, string> pair in dictionary)
        {
            d.Add(pair.Key, pair.Value);
        }
        dropDown.DataSource = new BindingSource(d, null);
        dropDown.DisplayMember = "Value";
        dropDown.ValueMember = "Key";
        dropDown.SelectedIndex = 0;
        return dropDown;
    }
