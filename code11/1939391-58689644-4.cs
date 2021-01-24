      string separatorDecimal = System.Threading.Thread.CurrentThread
                                .CurrentCulture.NumberFormat.NumberDecimalSeparator;
      bool hasDecimalSeparator = false;
      int posCarret = textBox1.SelectionStart;
      string result = "";
      for ( int index = 0; index < textBox1.Text.Length; index++ )
      {
        char c = textBox1.Text[index];
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
        if ( c == '+' || c == '-' )
        {
          if ( index == 0 )
            result += c;
        }
        else
        if ( char.IsDigit(c) )
          result += c;
      }
      textBox1.Text = result;
      textBox1.SelectionStart = posCarret;
