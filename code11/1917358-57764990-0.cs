        private bool _pendingScroll = false;
        private async void SessionRecords_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_pendingScroll) 
                return;
            _pendingScroll = true;
            try 
            {
                await System.Windows.Threading.Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
                if (e.NewItems?[0] != null)
                {
                    recordListView.ScrollIntoView(e.NewItems[0]);
                }
            }
            finally 
            {
                _pendingScroll = false;                        
            }
        }
