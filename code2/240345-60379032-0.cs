       public event EventHandler NewEvent
                {
                    add { Dimension.LengthChanged += value; }
                    remove { Dimension.LengthChanged -= value; }
                }
