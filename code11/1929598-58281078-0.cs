    public class MarketDetail
    {
        public string marketId { get; set; }
        public string course { get; set; }
    }
          public void myRaceList()
          {
            listBox1.DisplayMember = "course";
            listBox1.ValueMember = "marketId";
            listBox1.DataSource = new BindingSource(marketDictionary.Values, null);
          }
