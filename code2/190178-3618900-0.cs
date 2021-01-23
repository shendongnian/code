        if (_cached == null)
        {
          _cached = new List<TextBox>();
 
          foreach(var control in Controls)
          {
             TextBox textEdit = control as TextBox;
             if (textEdit != null)
             {
               textEdit.ReadOnly = false;
               _cached.Add(textEdit);
             }
          }
       } 
       else
       {
         foreach(var control in _cached)
          {
            
               control .ReadOnly = false;
          }
       }
