     protected void yourLiteral_DataBinding(object sender, System.EventArgs e)
     {
         // You could get anything here to get a value including calling a DB
         // call if you want for each item that is being bound.
         Literal lt = (Literal)(sender);
         int quantity = (int)(Eval("yourQuantityField"));
         _quantityTotal += quantity;
         lt.Text = quantity.ToString();
     }
