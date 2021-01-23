    public Window1(EventCode eventCode)
    {
        InitializeComponent();
        eventCode.MyEvent += new CustomEventHandler(ec_MyEvent);
    }
    void ec_MyEvent(object sender, CustomEventArgs args)
    {
        label1.Text = args.Message;
    }
