    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //From https://stackoverflow.com/a/978352/1210053
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var txt in FindVisualChildren<TextBox>(this))
            {
                txt.PreviewDragEnter += TextBox_PreviewDragEnter;
                txt.PreviewDragLeave += TextBox_PreviewDragLeave;
                txt.PreviewDrop += TextBox_PreviewDragLeave;
            }
            
        }
        private Dictionary<TextBox, int> oldZIndex = new Dictionary<TextBox, int>();
        private void TextBox_PreviewDragEnter(object sender, DragEventArgs e)
        {
            var txt = (TextBox)sender;
            oldZIndex.Add(txt, Panel.GetZIndex(txt));
            Panel.SetZIndex(txt, 1);
            var scaleTransform = new ScaleTransform(1.1, 1.1, txt.ActualWidth / 2, txt.ActualHeight / 2);
            txt.RenderTransform = scaleTransform;
        }
        private void TextBox_PreviewDragLeave(object sender, DragEventArgs e)
        {
            var txt = (TextBox)sender;
            txt.RenderTransform = null;
            Panel.SetZIndex(txt, oldZIndex[txt]);
            oldZIndex.Remove(txt);
        }             
    }
