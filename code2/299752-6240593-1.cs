    class ComboBoxItem
    {
    public string Name;
    public int Value;
    public ComboBoxItem(string Name, int Value)
    {
    this.Name = Name;
    this.Value = Value;
    }
    }
    myComboBox.Items.Add(new ComboBoxItem("Ashis Saha",1));
    myComboBox.Items.Add(new ComboBoxItem("Subrata Roy", 2));
    myComboBox.Items.Add(new ComboBoxItem("Aminul Islam", 3));
    myComboBox.Items.Add(new ComboBoxItem("Shakibul Alam", 4));
    myComboBox.Items.Add(new ComboBoxItem("Tanvir Ahmed", 5));
