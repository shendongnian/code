    private void Generic_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (((FrameworkElement)e.Source).GetType()   
               == typeof(System.Windows.Controls.Image))
        {
            Debug.WriteLine("image clicked");
            e.Handled = true;
        }
        else
        {
            Debug.WriteLine("grid clicked");
        }
   
    }
