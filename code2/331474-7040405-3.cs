    [ContentProperty("ContentChildren")]
    public class FixedSizeGrid : Grid
    {
        #region Dependency Properties
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
        public static readonly DependencyProperty ContentChildrenProperty =
            DependencyProperty.Register("ContentChildren",
                                        typeof(ObservableCollection<UIElement>),
                                        typeof(FixedSizeGrid),
                                        new FrameworkPropertyMetadata(new ObservableCollection<UIElement>()));
        #endregion // Dependency Properties
        #region Properties
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
        public ObservableCollection<UIElement> ContentChildren
        {
            get { return (ObservableCollection<UIElement>)GetValue(ContentChildrenProperty); }
            set { SetValue(ContentChildrenProperty, value); }
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
        #endregion // Properties
        #region Fields
        private List<Border> m_designTimeBorders;
        #endregion //Fields
        #region Constructor
        public FixedSizeGrid()
        {
            if (DesignerProperties.GetIsInDesignMode(this) == true)
            {
                m_designTimeBorders = new List<Border>();
            }
            SnapsToDevicePixels = true;
            Loaded += FixedSizeGrid_Loaded;
            ContentChildren.CollectionChanged += ContentChildren_CollectionChanged;
        }
        #endregion // Constructor
        #region Event Handlers
        private void FixedSizeGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRowDefinitions();
            UpdateColumnDefinitions();
        }
        private void ContentChildren_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (UIElement element in e.NewItems)
                {
                    RemoveFromParent(element);
                    Children.Add(element);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (UIElement element in e.OldItems)
                {
                    Children.Remove(element);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                Children.Clear();
            }
            if (DesignerProperties.GetIsInDesignMode(this) == true)
            {
                AddDesignTimeBorders();
            }
        }
        #endregion // Event Handlers
        #region Private Methods
        private void RemoveFromParent(UIElement element)
        {
            DependencyObject parent = element;
            while (parent != null && !(parent is FixedSizeGrid))
            {
                parent = LogicalTreeHelper.GetParent(parent);
            }
            if (parent != null)
            {
                (parent as FixedSizeGrid).Children.Remove(element);
            }
        }
        private void UpdateRowDefinitions()
        {
            while (RowDefinitions.Count > Rows && RowDefinitions.Count > 0)
                RowDefinitions.Remove(RowDefinitions[RowDefinitions.Count-1]);
            while (RowDefinitions.Count < Rows)
                RowDefinitions.Add(new RowDefinition());
            if (DesignerProperties.GetIsInDesignMode(this) == true)
            {
                AddDesignTimeBorders();
            }
        }
        private void UpdateColumnDefinitions()
        {
            while (ColumnDefinitions.Count > Columns && ColumnDefinitions.Count > 0)
                ColumnDefinitions.Remove(ColumnDefinitions[ColumnDefinitions.Count - 1]);
            while (ColumnDefinitions.Count < Columns)
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
                    m_designTimeBorders.Add(designTimeBorder);
                }
            }
            foreach (Border designTimeBorder in m_designTimeBorders)
            {
                Children.Add(designTimeBorder);
            }
        }
        private void RemoveDesignTimeBorders()
        {
            foreach (Border designTimeBorder in m_designTimeBorders)
            {
                Children.Remove(designTimeBorder);
            }
            m_designTimeBorders.Clear();
        }
        #endregion // Private Methods
    }
