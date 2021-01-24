    public partial class MainPage : Window
    {
        private SolidColorBrush[] treeColors => new[]
        {
            Brushes.Red,
            Brushes.Green,
            Brushes.Yellow,
            Brushes.Purple,
            Brushes.Blue
        };
        public MainPage()
        {
            InitializeComponent();
            Dictionary<string, object> data = new Dictionary<string, object>();
            Dictionary<string, object> child = new Dictionary<string, object>();
            child["child1"] = "hello";
            child["child2"] = "there";
            Dictionary<string, object> child2 = new Dictionary<string, object>();
            child2["sub1"] = "how";
            child2["sub2"] = "are";
            child2["sub3"] = "you";
            child["child3"] = child2;
            data["Variable1"] = child;
            child = new Dictionary<string, object>();
            child["child1"] = "lorem";
            child["child2"] = "ipsum";
            data["Variable2"] = child;
            foreach (var item in data)
            {
                MyTreeView.Items.Add(CreateTreeViewItem(item.Value, item.Key));
            }
        }
        private object CreateTreeViewItem(object obj, string header, int deep = 0)
        {
            // Next color but don't make an out of range
            if (deep > treeColors.Length - 1) deep = treeColors.Length - 1;
            var item = new TreeViewItem()
            {
                Header = header,
                Foreground = treeColors[deep]
            };
            // Create a new tree view item
            if (obj is Dictionary<string, object> dic)
            {
                foreach (var o in dic)
                {
                    item.Items.Add(CreateTreeViewItem(o.Value, o.Key, deep + 1));
                }
            }
            // Write the "header = value"
            else
            {
                item.Header = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Children =
                    {
                        new TextBlock
                        {
                            Text = header,
                            Foreground = treeColors[deep]
                        },
                        new TextBlock
                        {
                            Text = " = ",
                            Foreground = Brushes.White
                        },
                        new TextBlock
                        {
                            Text = obj.ToString(),
                            // Next color but don't make an out of range
                            Foreground = deep == treeColors.Length - 1? treeColors[deep]: treeColors[deep + 1]
                        },
                    }
                };
            }
            return item;
        }
    }
