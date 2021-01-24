    public string FooError { get; private set; }
    private string foo;
    public string Foo
    {
        get => return foo;
        set
        {
            foo = value;
            if (foo == "Bar") FooError = "";
            else FooError = "Foo must be Bar";
            NotifyPropertyChanged();
            NotifyPropertyChanged(nameof(FooError));
        }
     }
