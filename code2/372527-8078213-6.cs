    public KerningTextBlock()
    {
        UpdateLayout();
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(KerningTextBlock_Loaded);
    }
     void KerningTextBlock_Loaded(object sender, RoutedEventArgs e)
    {
         if (string.IsNullOrEmpty(Title.Text))
            this.InputText = "why am I empty?";
        else
            this.InputText = Title.Text;
        KernIt();
    }
