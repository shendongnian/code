    private List<TSPrice> GetPriceList()
    {
      return new List<TSPrice>
                 {
                   new TSPrice(0, ""),
                   new TSPrice(0, "Half Day"),
                   new TSPrice(0, "Full Day"),
                   new TSPrice(0, "1 + Half"),
                   new TSPrice(0, "2 Days"),
                   new TSPrice(0, "Formal Quote Required")
                 };
    }
    private void BindPriceList(ComboBox comboBox, List<TSPrice> priceList)
    {
      comboBox.DataSource = priceList();
      comboBox.ValueMember = "Price";
      comboBox.DisplayMember = "Description";
      comboBox.SelectedIndex = 0;
    }    
    BindPriceList(objInsuredPrice, GetPriceList());
    BindPriceList(objTPPrice, GetPriceList());
    BindPriceList(objProvSum, GetPriceList());
