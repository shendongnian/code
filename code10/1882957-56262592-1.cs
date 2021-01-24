    // Previous Implmentation
    
        /// <summary>
        /// Override of OnAppearing method. Fires as page is appearing.
        /// Good place to set up event handlers.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((INotifyCollectionChanged)MessagesListView.ItemsSource).CollectionChanged += OnListViewCollectionChanged;
        }
        /// <summary>
        /// Override of OnDisappearing method. Fires as page is disappearing.
        /// Good place to tear down event handlers.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((INotifyCollectionChanged)MessagesListView.ItemsSource).CollectionChanged -= OnListViewCollectionChanged;
        }
        /// <summary>
        /// Scrolls a the messages listview to the last item whenever
        /// a new message is added to the collection.
        /// </summary>
        private void OnListViewCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var myList = ((IEnumerable<Message>)MessagesListView.ItemsSource).ToList();
            // Must be ran on main thread or Android chokes.
            Device.BeginInvokeOnMainThread(async () =>
            {
                // For some reason Android requires a small delay or the scroll never happens.
                await Task.Delay(50);
                MessagesListView.ScrollTo(myList.Last(), ScrollToPosition.End, false);
            });
        }
    // Remaining Implementation
