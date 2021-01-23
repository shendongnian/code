     foreach (Control C in this.Controls)
     {
           if (C is TextBox)
           {
                if (C.Text == "")
                {
                     C.Text = null;
                 }
           }
     }
