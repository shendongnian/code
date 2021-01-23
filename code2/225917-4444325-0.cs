    private long _lastQuery = DateTime.Now.Ticks;
    public void Execute(object sender, object parameter)
    {
        var autoCompleteBox = sender as AutoCompleteTextBox;
        var e = parameter as SearchTextEventArgs;
        // removed unecessary code for clarity
        long lastQueryTag = _lastQuery = DateTime.Now.Ticks;
        Task.Factory.StartNew(() =>
        {                        
            var result = SearchUnderlyings(e.SearchText);
             System.Windows.Application.Current.Dispatch(() =>
             {
                 if (lastQueryTag == _lastQuery)
                      autoCompleteBox.ItemsSource = result;
             });
        });
    }
