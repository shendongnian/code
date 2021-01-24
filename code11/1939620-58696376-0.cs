    private Window2 win2;
    public void SomeButton_Click(object sender, RoutedEventArgs e)
    {
        win2?.Close();
        win2 = new Window2();
        win2.Show();
        win2.Topmost = true;
    }
