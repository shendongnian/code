    uc[i] = new UCMovieItem();
    uc[i].HorizontalAlignment = HorizontalAlignment.Right;
    uc[i].VerticalAlignment = VerticalAlignment.Top;
    uc[i].Margin = new Thickness(0, 10, 10, 0);
    uc[i].Cursor = Cursors.Hand;Button btn1 = new Button();
    uc[i].Click += btn_Click;
    
    
    //separate method
    private void btn_Click(object sender, RoutedEventArgs e)
    {
       //do your stuff here
       for (int i = 0; i < uc.Count; i++) // determine which index the button has in a loop
       {
            if ((sender as Button) == uc)
            {
                MessageBox.Show(i);
            }
       }
    }
