    private void search_DownloadStringCompleted(object sender,
                                                DownloadStringCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            this.result = e.Result;
            textBlock1.Text = this.result;
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        displayHTML(textBox1.Text);
    }
