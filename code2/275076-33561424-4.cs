        public Item CurrentItem
        {
            get { return _currentItem; }
            set
            {
                if (_currentItem == value) return;
                var oldItem = _currentItem;
                _currentItem = value;
                if (oldItem != null && oldItem.CurrentCell == this)
                {
                    oldItem.CurrentCell = null;
                }
                if (value != null)
                {
                    value.CurrentCell = this;
                }
            }
        }
