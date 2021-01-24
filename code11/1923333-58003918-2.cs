    int priceTotal = 0;
    
      if (smallPizzaCheck.Checked==true) 
     {
      priceTotal = priceTotal + 10;
     }
    
     else if (mediumPizzaCheck.Checked==true) 
     {
     priceTotal = priceTotal + 13;
     }
    
     //Et cetera, et cetera
    
     orderTotal.Text = Convert.ToString(priceTotal);
