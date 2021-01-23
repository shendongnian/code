      void Bind(Control c, ContextMenu menu)
      {
         foreach (Control subcontrol in c.Controls)
            Bind(subcontrol);
         TextBox textBox = c as TextBox;
         if (textBox != null)
         {
             textBox.ContextMenu = menu;
         }
      }
