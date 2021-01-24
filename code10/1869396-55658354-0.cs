           int i = 0;
     foreach (Control c in DrawingField.Controls)
        {
            if (c is TextBox)
            {
         
                TextBox txt = (TextBox)c;
                string str = txt.Text;
                TBValues[i] = str;
                i++;
            }
        }
        foreach (var key in TBValues)
        {
            MessageBox.Show(key);
        }
