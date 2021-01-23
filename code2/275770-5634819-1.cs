    public Form1(){
        InitializeComponent();
        SomeOtherClass.Instance.MyEvent += new SomeDelegate(MyMethod);
    }
    private void MyMethod()
    {
        if (this.IsHandleCreated)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // ... some code ...
            }
        }
    }
