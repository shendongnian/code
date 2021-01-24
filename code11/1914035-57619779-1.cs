    public List<Person> PersonList { get; set; } = new List<Person>
    {
        new Person { FirstName = "ABC", LastName = "123" },
        new Person { FirstName = "DEF", LastName = "456" },
        new Person { FirstName = "GHI", LastName = "789" }
    };
    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (var person in PersonList)
        {
            var listBoxItem = LstBx.ItemContainerGenerator.ContainerFromItem(person);
            var contentPresenter = FindVisualChild<ContentPresenter>(listBoxItem);
            var target = contentPresenter.ContentTemplate.FindName("tb1", contentPresenter) as TextBox;
    
            if (target != null)
            {
                var binding = new Binding
                {
                    // Remember each ListBoxItem's DataContext is the individual item 
                    // in the list, not the list itself.
                    Source = person, 
                    Path = new PropertyPath(nameof(Person.LastName)),
                    // Depends on what you need.
                    //Mode = BindingMode.TwoWay,
                    //UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };
    
                BindingOperations.SetBinding(target, TextBox.TextProperty, binding);
            }
        }
    }
    // Available from MSDN
    private Child FindVisualChild<Child>(DependencyObject obj) where Child : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            var child = VisualTreeHelper.GetChild(obj, i);
            if (child != null && child is Child)
            {
                return (Child)child;
            }
            else
            {
                var childOfChild = FindVisualChild<Child>(child);
    
                if (childOfChild != null) { return childOfChild; }
            }
        }
        return null;
    }
    
