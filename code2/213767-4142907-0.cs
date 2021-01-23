    private bool TryReadClear(TextBox txtBox, out double value)
    {
      if (double.TryParse(txtBox.Text, out value))
      {
        txtBox.BackColor = Color.White;
        return true;
      }
      else
      {
        txtBox.BackColor = Color.Red;
        txtBox.Text = string.Empty;
        return false;
      }
    }
