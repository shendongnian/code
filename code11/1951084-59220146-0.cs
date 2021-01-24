    private Rectangle GetColumnRectangle(int colNumber, int rowsNumber)
        {
            Rectangle rect = new Rectangle();
            rect.Fill = _columnNormal;
            rect.SetValue(Grid.ColumnProperty, colNumber);
            rect.SetValue(Grid.RowSpanProperty, rowsNumber);
            rect.SetValue(Grid.ZIndexProperty, 10);
            //Subscribe to events
            rect.MouseEnter += OnColumnMouseEnter;
            rect.MouseLeave += OnColumnMouseLeave;
            rect.MouseDown += OnColumnSelected;
            return rect;
        }
