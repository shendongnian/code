    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (s, e) => 
            {
                ModernMenu mm = FindVisualChildren<ModernMenu>(this).FirstOrDefault();
                if(mm != null)
                {
                    ListBox lb = FindVisualChildren<ListBox>(mm)?.ElementAt(1);
                    if (lb != null)
                    {
                        ListBoxItem link = FindVisualChildren<ListBoxItem>(lb).FirstOrDefault(x => x.Content == theLink);
                        if (link != null)
                            link.IsEnabled = false;
                    }
                }
            };
        }
    }
