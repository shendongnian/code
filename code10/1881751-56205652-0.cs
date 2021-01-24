    List<TextBox> tl = new List<TextBox>(){ ... };
    List<Grid> gl = new List<Grid>(){ ... }
    for (i=0; i<20; i++)
        {
            gl[i].Children.Add(tl[i]);
            container.Children.Add(gl[i]);
        }
            
    
