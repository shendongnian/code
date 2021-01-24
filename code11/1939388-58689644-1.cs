    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      int pos = textBox1.SelectionStart;
      string result = "";
      foreach ( char c in textBox1.Text )
        if ( char.IsDigit(c) )
          result += c;
      textBox1.Text = result;
      textBox1.SelectionStart = pos;
    }
