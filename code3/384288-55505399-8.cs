    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            var text_block = new TextBlock();
            
            Content = new DockPanel()
    
                .AddChildren(
    
                    new StatusBar()
                        .SetDock(Dock.Bottom)
                        .SetItemsPanel(
                            new ItemsPanelTemplate()
                                .SetVisualTree(
                                    new FrameworkElementFactory(typeof(Grid))
                                        .AppendChildren(
                                            new FrameworkElementFactory(typeof(ColumnDefinition))
                                                .SetValue_(ColumnDefinition.WidthProperty, new GridLength(100)),
                                            new FrameworkElementFactory(typeof(ColumnDefinition))
                                                .SetValue_(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto)),
                                            new FrameworkElementFactory(typeof(ColumnDefinition))
                                                .SetValue_(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star)),
                                            new FrameworkElementFactory(typeof(ColumnDefinition))
                                                .SetValue_(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto)),
                                            new FrameworkElementFactory(typeof(ColumnDefinition))
                                                .SetValue_(ColumnDefinition.WidthProperty, new GridLength(100)))))
                        .AddItems(
                            new StatusBarItem() { Content = text_block }.SetColumn(0),
                            new Separator().SetColumn(1),
                            new StatusBarItem() { Content = new TextBlock() { Text = "abc" } }.SetColumn(2),
                            new Separator().SetColumn(3),
                            new StatusBarItem() { Content = new ProgressBar() { Value = 50, Width = 90, Height = 16 } }.SetColumn(4)),
    
                    new TextBox() { AcceptsReturn = true }
                        .AddSelectionChanged(
                            (sender, e) =>
                            {
                                var box = sender as TextBox;
    
                                var row = box.GetLineIndexFromCharacterIndex(box.CaretIndex);
                                var col = box.CaretIndex - box.GetCharacterIndexFromLineIndex(row);
    
                                text_block.Text = $"Line {row + 1}, Char {col + 1}";
                            }));
        }
    }
