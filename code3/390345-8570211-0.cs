    private void button1_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var google = ((Button)sender).Content.ToString() == "Google";
            var run1 = new Run(textBox1.Text);
            var hl = new Hyperlink(run1)
            {
                NavigateUrl = google ? "http://www.google.com.ua/#hl=ru&source=hp&biw=1280&bih=933&q=" :
                                       "http://yandex.ua/yandsearch?text=";
                Tag = i;
            };
            var tb = new TextBlock();
            hl.Click += new RoutedEventHandler(hl_Click);
            tb.Inlines.Add(hl);
            tb.Inlines.Add(" ");
            wrapPanel1.Children.Add(tb);
            col1_links.Add(hl.NavigateUrl + HttpUtility.UrlEncode(textBox1.Text));
            col1_texts.Add(textBox1.Text);
            webBrowser1.Navigate(col1_links[i].ToString());
            i++;
            SaveData();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
