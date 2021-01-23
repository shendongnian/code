    **//Only numeric with Two decimal place comes in textbox and if user want to enter decimal again or space it will not allowed.**
    
     if ((e.Key >= Key.D0 && e.Key <= Key.D9 ||
                    e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Decimal || e.Key == Key.OemPeriod))
                {
                    string strkey = e.Key.ToString().Substring(e.Key.ToString().Length - 1, e.Key.ToString().Length - (e.Key.ToString().Length - 1));
    
                    if (e.Key >= Key.D0 && e.Key <= Key.D9 ||
                        e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                    {
    
                        TextBox tb = sender as TextBox;
                        int cursorPosLeft = tb.SelectionStart;
                        int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
                        string result1 = tb.Text.Substring(0, cursorPosLeft) + strkey + tb.Text.Substring(cursorPosRight);
                        string[] parts = result1.Split('.');
                        if (parts.Length > 1)
                        {
                            if (parts[1].Length > 2 || parts.Length > 2)
                            {
                                e.Handled = true;
                            }
                        }
                    }
    
                    if (((TextBox)sender).Text.Contains(".") && e.Key == Key.Decimal)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
    
                if (e.Key >= Key.A && e.Key <= Key.Z ||
                        e.Key == Key.Space)
                {
                    e.Handled = true;
                }
    
                if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.OemPeriod)
                {
                    e.Handled = true;
                }
