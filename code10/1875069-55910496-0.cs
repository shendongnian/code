c#
        public object SelectedItem
        {
            // This has to be done to cope with apparent bugs in the Ribbon controls.
            get => this.MyCollectionView.CurrentItem;
            set => this.MyCollectionView.MoveCurrentTo(value);
        }
The above will work in one direction from the UI, additional code will need to be added to handle the ICollectionView changing the CurrentItem programmatically and raise a PropertyChanged event.
