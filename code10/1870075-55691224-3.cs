    uc[i] = new UCMovieItem();
    uc[i].HorizontalAlignment = HorizontalAlignment.Right;
    uc[i].VerticalAlignment = VerticalAlignment.Top;
    uc[i].Margin = new Thickness(0, 10, 10, 0);
    uc[i].Cursor = Cursors.Hand;Button btn1 = new Button();
    uc[i].Click += btn_Click;
    
    
    //separate method
    private void btn_Click(object sender, RoutedEventArgs e)
    {
       int index = 0;
       for (int i = 0; i < uc.Length; i++) // determine which index the button has in a loop
       {
            if ((sender as Button) == uc[i])
            {
                index = i;
                MessageBox.Show(i);
            }
       }
       //do your stuff here
    }
