    class MyForm : IMyForm
    {
        private MethodThatAddsAControl()  //includes includes InitializeComponent as well as several others called at later
        {
            MyControl newControl = new MyControl(this);
            //other initialization as needed
            this.Controls.Add(newControl);   //this will raise MyControl ：：pForm_ControlAdded
        }
    }
    
    
    class MyControl : Control
    {
        Myform pForm;
        public MyControl(MyForm ff)
        {
          InitializeComponent();
          pForm=ff;
          pForm.ControlAdded+=new ControlEventHandler(pForm_ControlAdded);
        }
        
    }
