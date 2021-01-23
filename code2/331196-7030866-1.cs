    public class ComboBoxItem<T> {
    	public string FriendlyName { get; set; }
    	public T Value { get; set; }
    
    	public ComboBoxItem(string friendlyName, T value) {
    		FriendlyName = friendlyName;
    		Value = value;
    	}
    
    	public override string ToString() {
    		return FriendlyName;
    	}
    };
    
    // ...
    List<ComboBoxItem<int>> comboBoxItems = new List<ComboBoxItem<int>>();						
    for (int i = 0; i < 10; i++) {
    	comboBoxItems.Add(new ComboBoxItem<int>("Item " + i.ToString(), i));
    }
    
    _comboBox.DisplayMember = "FriendlyName";
    _comboBox.ValueMember = "Value";
    _comboBox.DataSource = comboBoxItems;
    
    
    _comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => {
    	Console.WriteLine("Selected Text:" + _comboBox.SelectedText);
    	Console.WriteLine("Selected Value:" + _comboBox.SelectedValue.ToString());
    };
