            public Item CurrentItem
        {
            get { return _currentItem; }
            set
            {
                if (value == null)
                {
                    _currentItem.Cell = null;
                }
                _currentItem = value;
                if (value != null && value.Cell != this)
                {
                    value.Cell = this;
                }
            }
        }
