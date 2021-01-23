    Control FindControl(string name)
    {
        foreach (Control c in this.Controls)
        {
             if (c.Name == name)
             {
                  return c;
             }
         }
         return null;
     }
