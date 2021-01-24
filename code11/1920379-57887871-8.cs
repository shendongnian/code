    private void TbSalary_TextChanged(object sender, EventArgs e) {
      TextBox box = sender as TextBox;
      StringBuilder sb = new StringBuilder();
      bool hasComma = false;
      foreach (var c in box.Text)
        if (c >= '0' && c <= '9')
          sb.Append(c);
        else if (c == ',' && !hasComma) {
          hasComma = true;
          if (sb.Length <= 0) // we don't start from comma
            sb.Append('0');
          sb.Append(c);
        }
      string text = sb.ToString();
      if (!text.Equals(box.Text))
        box.Text = text;
    }
