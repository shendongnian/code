    Helper helper = new Helper(url);
    public MainPage()
    {
        InitializeComponent();
        Helper.ResponseResult += ResponseHandler;
        Helper.invoke(output);
    }
    public void ResponseHandler(string response)
    {
        // do something with response
    }
