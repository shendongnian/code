    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        this.Dispatch(() =>
        {
            LoadTextBlock.Visibility = Visibility.Hidden;
            if (e.Error == null)
            {
                foreach (TechNews news in (e.Result as List<TechNews>))
                {
                    NewsListBox.Items.Add(news);
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message, "Error");
            }
        });
    }
