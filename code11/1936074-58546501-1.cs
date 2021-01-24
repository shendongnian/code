    public MainWindow()
    {
        InitializeComponent();
        //  More about this guy later
        DynamicDataTemplateCreator creator = this.FindResource("DynamicDataTemplateCreator") 
            as DynamicDataTemplateCreator;
        //  This gibberish is a stand in for whatever information the template creator 
        //  may need to figure out what type of view belongs to what type of viewmodel. 
        creator.ViewLookupInformation = 
            "My expatriate aunt Sally ate nine autumnal polar bears in Zanzibar.";
        DataContext = new MainViewModel();
    }
