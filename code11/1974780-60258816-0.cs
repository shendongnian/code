    private Dictionary<string, string> _conditions = new Dictionary<string, string>();
    
    private void UpdateFilter()
    {
         var activeConditions = _conditions.Where(c => c != null).Select(c => "(" + c.Value + ")");
         DataView dv = DataGrid1.ItemsSource as DataView;
         dv.RowFilter = string.Join(" AND ", activeConditions);
    }
    private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        string filter = NameSearch.Text;
        if (string.IsNullOrEmpty(filter))
            _conditions["name"] = null;
        else
            _conditions["name"] = string.Format("NAME Like '%{0}%'", filter);
        UpdateFilter();
    }
    private void TextBox_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        string filter = ActiveSearch.Text;
        if (string.IsNullOrEmpty(filter))
            _conditions["active"] = null;
        else
            _conditions["active"] = string.Format("ACTIVE Like '%{0}%'", filter);
        UpdateFilter();
    }
    private void CustomerNumberSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        string filter = CustomerNumberSearch.Text;
        if (string.IsNullOrEmpty(filter))
            _conditions["nro"] = null;
        else
            _conditions["nro"] = string.Format("NRO Like '%{0}%'", filter); //this should be "Begins with" not "Like"
        UpdateFilter();
    }
