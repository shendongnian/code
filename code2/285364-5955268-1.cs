    [DataMember]
    internal MyClass MyProperty {get; set;}
    public MyClass MyPropertySync {get; set;}
    public MyClass MyPropertyAsync {get; set;}
    
    private MyClass _myProperty;
    private bool _isMyPropertyLoaded;
    
    private async void LoadMyPropertyAsync();
    private async Task<MyClass> GetMyPropertyAsync();
    private MyClass GetMyPropertySync();
