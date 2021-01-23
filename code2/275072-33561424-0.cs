            public Cell Cell
        {
            get { return _cell; }
            set
            {
                if (value == null)
                {
                    _cell.CurrentItem = null;
                }
                _cell = value;
                if (value != null && value.CurrentItem != this)
                {
                    value.CurrentItem = this;
                }
            }
        }
