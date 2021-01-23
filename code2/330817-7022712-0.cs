    private void opbtn_Click(object sender, RoutedEventArgs e)
    {
        op.BorderBrush = System.Windows.Media.Brushes.Blue;
        op.UpdateLayout();
        DateTime obj1 = new DateTime(); 
        DateTime obj2 = DateTime.Now.AddMilliseconds(200);
        while (obj2 > obj1)
        {
            obj1 = DateTime.Now;
        }
        op.BorderBrush = System.Windows.Media.Brushes.Red;
    }
