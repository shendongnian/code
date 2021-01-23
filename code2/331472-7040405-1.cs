    public class FixedSizeGrid : Grid
    {
        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows",
                                        typeof(int),
                                        typeof(FixedSizeGrid),
                                        new FrameworkPropertyMetadata(24, RowsPropertyChanged));
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns",
                                        typeof(int),
                                        typeof(FixedSizeGrid),
                                        new FrameworkPropertyMetadata(80, ColumnsPropertyChanged));
        private static void RowsPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FixedSizeGrid fixedSizeGrid = sender as FixedSizeGrid;
            fixedSizeGrid.UpdateRowDefinitions();
        }
        private static void ColumnsPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            FixedSizeGrid fixedSizeGrid = sender as FixedSizeGrid;
            fixedSizeGrid.UpdateColumnDefinitions();
        }
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }
        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }
        public FixedSizeGrid()
        {
            SnapsToDevicePixels = true;
            Loaded += FixedSizeGrid_Loaded;
        }
        void  FixedSizeGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRowDefinitions();
            UpdateColumnDefinitions();
        }
        private void UpdateRowDefinitions()
        {
            RowDefinitions.Clear();
            for (int i = 0; i < Rows; i++)
                RowDefinitions.Add(new RowDefinition());
            if (DesignerProperties.GetIsInDesignMode(this) == true)
            {
                AddDesignTimeBorders();
            }
        }
        private void UpdateColumnDefinitions()
        {
            ColumnDefinitions.Clear();
            for (int i = 0; i < Columns; i++)
                ColumnDefinitions.Add(new ColumnDefinition());
            if (DesignerProperties.GetIsInDesignMode(this) == true)
            {
                AddDesignTimeBorders();
            }
        }
        private void AddDesignTimeBorders()
        {
            RemoveDesignTimeBorders();
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    Border designTimeBorder = new Border();
                    designTimeBorder.Tag = "DesignTimeBorder";
                    designTimeBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(154, 191, 229));
                    designTimeBorder.BorderThickness = new Thickness(0,0,1,1);
                    Grid.SetRow(designTimeBorder, row);
                    Grid.SetColumn(designTimeBorder, column);
                    this.Children.Add(designTimeBorder);
                }
            }
        }
        private void RemoveDesignTimeBorders()
        {
            for (int i = 0; i < Children.Count; i++)
            {
                UIElement child = Children[i];
                if (child is Border)
                {
                    Border border = child as Border;
                    if (border.Tag.ToString() == "DesignTimeBorder")
                    {
                        Children.Remove(border);
                    }
                }
            }
        }
    }
