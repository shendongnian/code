    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    
    namespace WpfTutorialStatusBarGridCs
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                
                var dock_panel = new DockPanel();
    
                Content = dock_panel;
    
    
                var status_bar = new StatusBar();
    
                dock_panel.Children.Add(status_bar);
    
                DockPanel.SetDock(status_bar, Dock.Bottom);
    
                var items_panel_template = new ItemsPanelTemplate();
    
                {
                    var grid_factory = new FrameworkElementFactory(typeof(Grid));
    
                    {
                        {
                            var col = new FrameworkElementFactory(typeof(ColumnDefinition));
    
                            col.SetValue(ColumnDefinition.WidthProperty, new GridLength(100));
    
                            grid_factory.AppendChild(col);
                        }
    
                        {
                            var col = new FrameworkElementFactory(typeof(ColumnDefinition));
    
                            col.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
    
                            grid_factory.AppendChild(col);
                        }
    
                        {
                            var col = new FrameworkElementFactory(typeof(ColumnDefinition));
    
                            col.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));
    
                            grid_factory.AppendChild(col);
                        }
    
                        {
                            var col = new FrameworkElementFactory(typeof(ColumnDefinition));
    
                            col.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
    
                            grid_factory.AppendChild(col);
                        }
    
                        {
                            var col = new FrameworkElementFactory(typeof(ColumnDefinition));
    
                            col.SetValue(ColumnDefinition.WidthProperty, new GridLength(100));
    
                            grid_factory.AppendChild(col);
                        }
                    }
    
                    items_panel_template.VisualTree = grid_factory;
                }
    
                status_bar.ItemsPanel = items_panel_template;
    
    
    
                var text_block = new TextBlock();
    
    
                {
                    var status_bar_item = new StatusBarItem();
    
                    Grid.SetColumn(status_bar_item, 0);
    
                    status_bar_item.Content = text_block;
    
                    status_bar.Items.Add(status_bar_item);
                }
    
                {
                    var separator = new Separator();
    
                    Grid.SetColumn(separator, 1);
    
                    status_bar.Items.Add(separator);
                }
    
                {
                    var status_bar_item = new StatusBarItem();
    
                    Grid.SetColumn(status_bar_item, 2);
    
                    status_bar_item.Content = new TextBlock() { Text = "abc" };
    
                    status_bar.Items.Add(status_bar_item);
                }
    
                {
                    var separator = new Separator();
    
                    Grid.SetColumn(separator, 3);
    
                    status_bar.Items.Add(separator);
                }
    
                {
                    var status_bar_item = new StatusBarItem();
    
                    Grid.SetColumn(status_bar_item, 4);
    
                    status_bar_item.Content = new ProgressBar() { Value = 50, Width = 90, Height = 16 };
    
                    status_bar.Items.Add(status_bar_item);
                }
    
                {
                    var text_box = new TextBox() { AcceptsReturn = true };
    
                    text_box.SelectionChanged += (sender, e) => 
                    {
                        var row = text_box.GetLineIndexFromCharacterIndex(text_box.CaretIndex);
                        var col = text_box.CaretIndex - text_box.GetCharacterIndexFromLineIndex(row);
    
                        text_block.Text = $"Line {row + 1}, Char {col + 1}";
                    };
    
                    dock_panel.Children.Add(text_box);
                }
            }
        }
    }
