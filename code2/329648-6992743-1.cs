        private Queue<string> _items = new Queue<string>();
        private List<string> _results = new List<string>();
        private void PopulateItemsQueue()
        {
            _items.Enqueue("some_url_here");
            _items.Enqueue("perhaps_another_here");
            _items.Enqueue("and_a_third_item_as_well");
            DownloadItem();
        }
        private void DownloadItem()
        {
            if (_items.Any())
            {
                var nextItem = _items.Dequeue();
                var webClient = new WebClient();
                webClient.DownloadStringCompleted += OnGetDownloadedStringCompleted;
                webClient.DownloadStringAsync(new Uri(nextItem));
                return;
            }
            ProcessResults(_results);
        }
        private void OnGetDownloadedStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && !string.IsNullOrEmpty(e.Result))
            {
                // do something with e.Result string.
                _results.Add(e.Result);
            }
            DownloadItem();
        }
