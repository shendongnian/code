    public string passValue;
    
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        //labeltwo is a Label Control in ControllerB
        labeltwo.Text = passValue ; // here can get data from ControllerA
    }
