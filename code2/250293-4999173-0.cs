        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //Gets current date and puts it into string.
        string today = DateTime.Now.ToString("yyyy.MM.dd");
        string yesterday = DateTime.Now.AddDays(-1).ToString("yyyy.MM.dd");
        TextBoxToday.Text = "" + today;
        TextBoxYesterday.Text = "" + yesterday;
        try
        {
                FileInfo f = new FileInfo("D:\\Client1\\2011.02.14.log");
                {
                    if (f.Length > 0)
                        ButtonToday.Background = Brushes.Green;
                    else
                        ButtonToday.Background = Brushes.Red;
                }
        }
        catch ( SecurityException ex )
        {
                ex.Message;
        }
