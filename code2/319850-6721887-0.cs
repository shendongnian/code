    //generate your array.
    List<string> twos = new List<string>();
    
    int item = 2;
    int max = int.MaxValue / 2;
    while ((item = 2 * item) < max)
    {
        twos.Add(item.ToString());
    }
 
    ComboBox comboBox1 = new ComboBox();
    comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
    comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
    comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    comboBox1.FormattingEnabled = true;
    //comboBox1.Items.Clear();
    comboBox1.Items.AddRange(twos.ToArray());
    comboBox1.AutoCompleteCustomSource.AddRange(twos.ToArray());
    this.Controls.Add(comboBox1);
