    private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (Char.IsLetter(e.KeyChar))
      {
        int p = this.SelectionStart;
        this.Text = this.Text.Insert(this.SelectionStart, Char.ToUpper(e.KeyChar).ToString());
        this.SelectionStart = p + 1;
      }
    }
