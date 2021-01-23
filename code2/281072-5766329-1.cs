    private myClass _test;
    private void button2_Click(object sender, RoutedEventArgs e)
    {
        int a = 1;
    
        if (_test == null)
        {
            _test = new myClass(a);
        }
    }
