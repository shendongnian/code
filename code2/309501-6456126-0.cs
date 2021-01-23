    if (!(item is Label | item is LiteralControl))
    {
          if(item is TextBox)
          {
            TextBox textBox = (TextBox)item;
            string textValue = textBox.Text;
          }
          ...
    
    }
