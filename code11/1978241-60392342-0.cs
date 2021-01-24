    public ObservableCollection<int> Chars { get; set; }
    
    private async void ClickItem(object sender, RoutedEventArgs e)
    {
          await Dispatcher.BeginInvoke((Action)delegate () 
          {
               for (int i = 1; i <= 3; i++)
               {
                    Chars.Add(Chars.Count + 1);
               }                
           }, DispatcherPriority.Input);
    }
