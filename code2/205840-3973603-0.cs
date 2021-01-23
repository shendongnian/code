    public class TextSearchViewModel
    {
        public TextSearchViewModel
        {
            // If there is no text (or whitespace only) then the search button is disabled.
            var isSearchEnabled = this.ObservableForProperty(x => x.SearchText)
                .Select(x => !String.IsNullOrWhitespace(x.Value));
            // Create an ICommand that represents the Search button
            // Setting 1 at a time will make sure the Search button disables while search is running
            DoSearch = new ReactiveAsyncCommand(isSearchEnabled, 1/*at a time*/);
            // When the user clicks search the text box and the search button are both disabled.
            var textBoxEnabled = DoSearch.ItemsInflight
                .Select(x => x == 0);
            // Always update the "TextboxEnabled" property with the latest textBoxEnabled IObservable
            _TextboxEnabled = this.ObservableToProperty(textBoxEnabled, 
                x => x.TextboxEnabled, true);
            // Register our search function to run in a background thread - for each click of the Search
            // button, the searchResults IObservable will produce a new OnNext item
            IObservable<IEnumerable<MyResult>> searchResults = DoSearch.RegisterAsyncFunction(textboxText => {
                var client = new MySearchClient();
                return client.DoSearch((string)textboxText);
            });
            // Always update the SearchResults property with the latest item from the searchResults observable
            _SearchResults = this.ObservableToProperty(searchResults, x => x.SearchResults);
        }
        // Create a standard INotifyPropertyChanged property
        string _SearchText;
        public string SearchText {
            get { return _SearchText; }
            set { this.RaiseAndSetIfChanged(x => x.SearchText, value); }
        }
        // This is a property who will be updated with the results of an observable
        ObservableAsPropertyHelper<bool> _TextboxEnabled;
        public bool TextboxEnabled {
            get { return _TextboxEnabled.Value; }
        }
        // This is an ICommand built to do tasks in the background
        public ReactiveAsyncCommand DoSearch { get; protected set; }
        // This is a property who will be updated with the results of an observable
        ObservableAsPropertyHelper<IEnumerable<MyResult>> _SearchResults;
        public IEnumerable<MyResult> SearchResults {
            get { return _SearchResults.Value; }
        }
    } 
