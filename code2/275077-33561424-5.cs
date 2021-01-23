        public Cell CurrentCell
        {
            get { return _currentCell; }
            set
            {
                if (_currentCell == value) return;
                var oldCell = _currentCell;
                _currentCell = value;
                if (oldCell != null && oldCell.CurrentItem == this)
                {
                    oldCell.CurrentItem = null;
                }
                if (value != null)
                {
                    value.CurrentItem = this;
                }
            }
        }
