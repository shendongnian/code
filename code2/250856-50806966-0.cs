    AccessText a = new AccessText();    
    a.Text=reader[1].ToString();       // MySql reader
    a.Width = 70;
    a.TextWrapping = TextWrapping.WrapWithOverflow;
    labels[i].Content = a;
                    
