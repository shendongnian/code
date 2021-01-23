      Control.ControlCollection coll = this.Controls;
      foreach(Control c in coll) 
      {
        if(c != null)
        {
           if (d.ContainsKey(c.Name))
           {
             c.Text = d[c.Name];
           }
        }
      }
