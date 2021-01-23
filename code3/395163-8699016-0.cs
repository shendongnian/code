    void _tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_tm == (sender as Timer))
            {
                _main.ContentPage.Children.Clear();
                _main.ContentPage.Children.Add(_homeScreen);
            }
        }
