    public void TextBox_GotFocus(object sender, RoutedEventArgs e)
    {
       
       TextBox tb = (TextBox)sender;
    
       if(tb.Text != "SOME DEFAULT TEXT")
       {
          
         String persentContentWithDefaultString = t.Text as string;
         tb.Text = persentContentWithDefaultString[0].ToString();
         // set cursor position 
          tb.Select(1, 0);         
    
          tb.GotFocus -= TextBox_GotFocus;
     }
    }
