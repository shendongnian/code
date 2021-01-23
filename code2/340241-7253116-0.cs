      protected void lv_Productos_OnItemCommand(object sender, ListViewCommandEventArgs e)
      {
        if (String.Equals(e.CommandName, "AddProduct"))
        {
          // Get a reference to your textbox in this item
          TextBox textbox = e.Item.FindControl("QuantityTextBox") as TextBox;
          
          if (textbox != null)
          {
              int quant = 0;
              if (int.TryParse(textbox.Value, quant))
              {
                 int prodId = (int)e.CommandArgument;
    
                 //do what you want with the quantity and product id
              }
          }
    
        }
      }
