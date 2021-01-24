        public partial class TextBlockControl : UserControl
    {
        public List<string> name => DataContext as List<string>;
        public TextBlockControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
                foreach (var t in name)
                {
                    var run = new Run(t.Text);
                    if (t.IsHighlighted)
                    {
                        run.Foreground = Brushes.Green;
                    }
                    else
                    {
                        run.Foreground = Brushes.Red;
                    }
                    textBlock.Inlines.Add(run);
                }
            }
        }
    }
