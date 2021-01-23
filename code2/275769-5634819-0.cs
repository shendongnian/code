    public Form1(){
        InitializeComponent();
    }
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        SomeOtherClass.Instance.MyEvent += new SomeDelegate(MyMethod);
    }
    private void MyMethod()
    {
        this.Invoke((MethodInvoker)delegate
        {
            // ... some code ...
        }
    }
