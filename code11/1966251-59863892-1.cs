    class CustomGrid : Grid
    {
        public CustomGrid()
        {
            Loaded += CustomGrid_Loaded;
        }
        private void CustomGrid_Loaded(object sender, RoutedEventArgs e)
        {
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
            int nextRow = 0;
            int nextColumn = 0;
            foreach (UIElement child in Children)
            {
                //happens while editing the children collection in xaml
                //if we don't handle this, the Designer throws an exception
                if (child == null)
                    continue;
                string name = ((FrameworkElement)child).Name; // empty for the last child, when call from OnVisualChildrenChanged 
                if (nextRow >= RowDefinitions.Count)
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
                    SetRow(child, nextRow);
                    SetColumn(child, nextColumn);
                    nextColumn += GetColumnSpan(child);
                    if (nextColumn >= columnNb)
                    {
                        nextColumn = 0;
                        nextRow++;
                    }
                }
            }
        }
    }
