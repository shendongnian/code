    public TextWithUrlUserControl()
    {
        InitializeComponent();
    
        this.Loaded += (s, e) =>
                            {
                                foreach(var inline in ParseText(DataContext as string))
                                    txtContent.Inlines.Add(inline);
                            };
    } 
    IEnumerable<Inline> ParseText(string text)
    {
        // return list of Runs and Runs with hyperlinks using your URL parsing
        // for demo purposes, just hardcoding it here:
        return new List<Inline>
                    {
                        new Run{Text="This text has a "},
                        new Run{Text="URL", RunExtender.NavigateUrl="http://www.google.com/"},
                        new Run{Text="in it!"}
                    };    
    }
