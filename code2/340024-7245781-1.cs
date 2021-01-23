    private void comboBoxEdit1_QueryPopUp(object sender, CancelEventArgs e)
    {
      ComboBoxEdit cb = (ComboBoxEdit)sender;
      PropertyInfo pi = typeof(RepositoryItem).GetProperty("PropertyStore", BindingFlags.NonPublic | BindingFlags.Instance);
      HybridDictionary store = (HybridDictionary)pi.GetValue(cb.Properties, null);
      store["ComboPopupSize"] = new Size(100, 100);
    }
