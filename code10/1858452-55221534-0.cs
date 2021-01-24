    private void button_Click(object sender, RoutedEventArgs e)
    {
        var fc = Application.Current.Windows.OfType<newWindow>().FirstOrDefault();
        if (fc != null)
        {
            fc.Close();
        }
        nw = new newWindow(Id, Ip, name);
        nw.Show();
    }
