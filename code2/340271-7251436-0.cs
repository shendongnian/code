    private void txtData_TextChanged(object sender, TextChangedEventArgs e)
    {
      var pos = txtData.SelectionStart;
      string data = txtData.Text.Replace("$", "");
      txtData.Text = data;
      txtData.SelectionStart = pos;
    }
