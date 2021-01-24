    public partial class MainWindow : Window
        {
            public ObservableCollection<VM> Items { get; } = new ObservableCollection<VM> { new VM(), new VM(), new VM() };                             
    
            public MainWindow()
            {
                InitializeComponent();
    
                Items.CollectionChanged += Items_CollectionChanged;
    
                AddHandler(Validation.ErrorEvent, new RoutedEventHandler((s, e) =>
                Title = ((ValidationErrorEventArgs)e).Action == ValidationErrorEventAction.Added ? "+" : "-"));
    
                DataContext = this;        
            }
                   
            private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        if(tb.DataContext == e.OldItems[0])
                        {
                            Validation.ClearInvalid(tb.GetBindingExpression(TextBox.TextProperty));
                            break;
                        }                    
                    }
                }            
            }
    
            private void Button_Click(object sender, RoutedEventArgs e) => Items.RemoveAt(0);
    
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
    
        }
        public class VM
        { 
            public int Test { get; set; }
           
        }
