    for (int i = 0; i < 20; i++)
    {
        uc[i] = new UCMovieItem();
        ...
        mainWrapPanel.Children.Add(uc[i]);
    
        // little trick: we don't want to pass "i" to Clicked 
        // which will be "20" after the loop completed
        // but its local copy which will be 0..19 
        int number = i;
    
        // event handler as lambda
        uc[i].Clicked += (o, e) => {
          // Control itself will be passed explicitly
          UCMovieItem controlClicked = (o as UCMovieItem); 
     
          MessageBox.Show(number.ToString()); 
        }  
    }
