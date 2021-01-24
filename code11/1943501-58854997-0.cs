    private async void BackgroundWorker2_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      for (int i = 1; i <= 1048576; i++)
      {
        // Use Dispatcher because 
        // INotifyCollectionChanged.CollectionChanged is not raised on the UI thread 
        // (opposed to INotifyPropertyChanged.PropertyChanged)
        await Application.Current.Dispatcher.InvokeAsync(
          () => this.DataTableRowCollection.Add(new RowItem(i)),
          DispatcherPriority.Background);
      }
    }
