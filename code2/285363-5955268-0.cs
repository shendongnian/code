    public MyClass MyPropertySync {get; set;}
    public MyClass MyPropertyAsync {get; set;}
    
    [DataMember]
    private MyClass _myProperty;
    private bool _isMyPropertyLoaded;
    
    private async void LoadMyPropertyAsync();
    private async Task<MyClass> GetMyPropertyAsync();
    private MyClass GetMyPropertySync();
