    foreach(Control ctrl in control)
    {
       TextoBox tbx = ctrl as TextBox;
       if(tbx != null)
       {
             //do processing
             continue;
       }
       ComboBox cbx = ctrl as ComboBox;
       if(cbx != null)
       {
             //do processing
             continue;
       }
       //and so on
       
    }
