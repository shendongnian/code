    Entry m_nameentry; //to access it later outside of the constructor
    public TodoItemPage()
    {
        InitializeComponent();
        BindingContextChanged += TodoItemPage_BindingContextChanged; //put the code that should use the BindingContext Value inside
        //Title = "Name"; // here need show NAME - I can't display my name here
        //var nameEntry = new Entry();
        m_nameentry = new Entry();
        nameEntry.SetBinding(Entry.TextProperty, "Name");
        Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    //nameEntry, // here NAME is shown
                    m_nameentry
                }
            };
    }
    private void TodoItemPage_BindingContextChanged(object sender, EventArgs e)
    {
        Title = (BindingContext as Models.TodoItem).Name;
        m_nameentry.Text = (BindingContext as Models.TodoItem).Name;
    }
