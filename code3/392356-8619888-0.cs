    // Constructor
    public MyViewModel()
    {
        this._injectedModel = SetModel();
        this.MyCommand = new MyCommand(_injectedModel); 
    }
    ICommand MyCommand { get; private set; }
