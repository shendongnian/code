        public MainWindow()
        {
            InitializeComponent();
            this.textBox1.SpellCheck.CustomDictionaries.Add(new Uri("C:\\dict.txt", UriKind.Relative));
            textBox1.Text = "Lorem ipsum dolor sit amet";
            this.Closed += ((object sender, EventArgs e) => {
                foreach (var txtbox in FindVisualChildren<TextBox>(this))
                {
                    txtbox?.SpellCheck?.CustomDictionaries?.Clear();
                }
            });
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
