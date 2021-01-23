    private void Button_Click(object sender, RoutedEventArgs e)
    {
        RequestAsync(
            new Uri("http://www.knbsb.nl/nw/index.php?option=com_content&view=category&layout=blog&id=382&Itemid=150&lang=nl&LevelID=120&CompID=1580"),
            (html, exc) =>
                {
                    if (exc == null)
                    {
                        Dispatcher.BeginInvoke(() => MessageBox.Show(html));
                    }
                    else
                    {
                        // handle exception appropriately
                    }
                });
    }
