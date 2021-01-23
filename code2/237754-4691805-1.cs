    public class ComboItem
    {
        public string stringValue { get; set; }
        public int indexValue { get; set; }
    }
    
    public void LoadCombo()
    {
         List<ComboItem> list = new List<ComboItem>();
         // populate list...
         // then bind list
         myComboBox.DisplayMember = "stringValue";
         myComboBox.ValueMember = "indexValue";
         myComboBox.DataSource = list;
    }
