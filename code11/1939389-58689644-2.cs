    string separatorDecimal = System.Threading.Thread.CurrentThread
                              .CurrentCulture.NumberFormat.NumberDecimalSeparator;
    bool hasDecimalSeparator = false;
    int pos = textBox1.SelectionStart;
    string result = "";
    foreach ( char c in textBox1.Text )
    {
      if ( new string(c, 1) == separatorDecimal )
      {
        if ( hasDecimalSeparator )
          continue;
        else
        {
          hasDecimalSeparator = true;
          result += c;
        }
      }
      else
      if ( char.IsDigit(c) || c == '+' || c == '-' )
        result += c;
    }
    textBox1.Text = result;
    textBox1.SelectionStart = pos;
