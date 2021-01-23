     AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
     // AutoComplete
    public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e)
    {
          this.AutoComplete(cb, e, false);
    }
    public void AutoComplete(ComboBox cb,System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
    {
         string strFindStr = "";
         if (e.KeyChar == (char)8) 
         {
             if (cb.SelectionStart <= 1) 
             {
                 cb.Text = "";
                 return;
             }
            if (cb.SelectionLength == 0)
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
            else 
               strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
         }
        else 
        {
             if (cb.SelectionLength == 0)
                strFindStr = cb.Text + e.KeyChar;
             else
                 strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
         }
       int intIdx = -1;
        // Search the string in the ComboBox list.
         intIdx = cb.FindString(strFindStr);
         if (intIdx != -1)
         {
                 cb.SelectedText = "";
                 cb.SelectedIndex = intIdx;
                 cb.SelectionStart = strFindStr.Length;
                 cb.SelectionLength = cb.Text.Length;
                 e.Handled = true;
          }
          else
          {
               e.Handled = blnLimitToList;
           }
      }
