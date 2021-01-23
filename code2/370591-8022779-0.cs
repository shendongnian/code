    List<string> values = new List<string>();
        foreach(Control c in this.Controls)
        {
            if(c is TextBox)
            {
                
                TextBox tb = (TextBox)c;
                values.Add(tb.Text);
            }
         }
         string[] array = values.ToArray();
