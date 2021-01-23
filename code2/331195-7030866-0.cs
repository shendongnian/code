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
            
    //
    _comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => {
       Console.WriteLine("Selected Text:" + (ComboBoxItem<int>)_comboBox.SelectedItem);
       Console.WriteLine("Selected Value:" + (ComboBoxItem<int>)_comboBox.SelectedItem).Value);
            			};
            
        //
        for (int i = 0; i < 10; i++) {
            _comboBox.Items.Add(new ComboBoxItem<int>("Item " + i.ToString(), i));
        }
