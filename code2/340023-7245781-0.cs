    private void comboBoxEdit1_QueryPopUp(object sender, CancelEventArgs e)
    {
      ComboBoxEdit mx = (ComboBoxEdit)sender;
      FieldInfo fi = typeof(RepositoryItem).GetField("_propertyStore", BindingFlags.NonPublic | BindingFlags.Instance);
      PropertyInfo pi = typeof(RepositoryItem).GetProperty("PropertyStore", BindingFlags.NonPublic | BindingFlags.Instance);
      HybridDictionary store = (HybridDictionary)pi.GetValue(mx.Properties, null);
      store["ComboPopupSize"] = new Size(100, 100);
    }
