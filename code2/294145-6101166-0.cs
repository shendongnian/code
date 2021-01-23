    void Button_Click(object sender, RoutedEventArgs e) {
      using (BackgroundWorker worker = new BackgroundWorker()) {
        var items = new int[10000];
        worker.DoWork += delegate {
          for (int i = 0; i < items.Length; i++)
            items[i] = i + 1;
        };
        worker.RunWorkerCompleted += delegate {
          listBox.ItemsSource = items;
        };
        worker.RunWorkerAsync();
      }
    }
