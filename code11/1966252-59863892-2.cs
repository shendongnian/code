    class CustomGrid : Grid
    {
        private int _nextRow = 0;
        private int _nextColumn = 0;
        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            UpdateChildren();
        }
        void UpdateChildren()
        {
            int rowNb = RowDefinitions.Count;
            int columnNb = ColumnDefinitions.Count;
            if (columnNb == 0)
            {
                ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Star) });
                columnNb = ColumnDefinitions.Count;
            }
            foreach (UIElement child in Children)
            {
                //happens while editing the children collection in xaml
                //if we don't handle this, the Designer throws an exception
                if (child == null)
                    continue;
                string name = ((FrameworkElement)child).Name; // empty for the last child, when call from OnVisualChildrenChanged 
                if (_nextRow >= RowDefinitions.Count)
                    RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                bool rowIsDefined = child.ReadLocalValue(RowProperty) != DependencyProperty.UnsetValue;
                bool columnIsDefined = child.ReadLocalValue(ColumnProperty) != DependencyProperty.UnsetValue;
                if (rowIsDefined)
                {
                    for (int i = RowDefinitions.Count; i < GetRow(child) + 1; i++)
                        RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                }
                if (!rowIsDefined && !columnIsDefined)
                {
                    SetRow(child, _nextRow);
                    SetColumn(child, _nextColumn);
                    _nextColumn += GetColumnSpan(child);
                    if (_nextColumn >= columnNb)
                    {
                        _nextColumn = 0;
                        _nextRow++;
                    }
                }
            }
        }
    }
