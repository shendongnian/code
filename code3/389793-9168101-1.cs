        // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(LogViewerViewModel), typeof(LogViewerControl),
               new UIPropertyMetadata(null,pf_viewModelChanged));
        private static void pf_viewModelChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var control = (LogViewerControl)o;
            control.ColTimeStamp.SortDirection = ListSortDirection.Descending;
            var vm = e.NewValue as LogViewerViewModel;
            if (vm != null)
            {   
                ICollectionView collectionView = CollectionViewSource.GetDefaultView(vm.LogLister.Logs);
                collectionView.SortDescriptions.Add(new SortDescription("TimeStampLocal", ListSortDirection.Descending));
            }
        }
