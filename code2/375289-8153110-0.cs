            /// <summary>
        /// The <see cref="SelectedListItem" /> property's name.
        /// </summary>
        public const string SelectedStickPropertyName = "SelectedListItem";
        private SampleData _selectedItem;
        /// <summary>
        /// Gets the SelectedStick property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public SampleData SelectedListItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem == value || value == null)
                {
                    return;
                }
                var oldValue = _selectedItem;
                _selectedItem = value;
                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedStickPropertyName);
            }
        }
