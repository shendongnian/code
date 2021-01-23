    foreach(Control c in this.Controls)
    {
          if (c.GetType().FullName == "System.Windows.Forms.TextBox")
          {
              TextBox t = (TextBox)c;
              t.Clear();
          }
    }
