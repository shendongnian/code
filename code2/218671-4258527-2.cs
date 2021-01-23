    class MyForm : IMyForm
            {
                private MethodThatAddsAControl()  //includes includes InitializeComponent as well as several others called at later
                {
                 //create a MyControl object and add it to MyForm
                   MyControl newControl = new MyControl(this);
                 //other initialization as needed
                  this.Controls.Add(newControl);   //this will raise MyControl::pForm_ControlAdded
        
                    //create a MyControl object and add it to MyPanel1
                    MyControl newControl = new MyControl(MyPanel1); //pass panel reference            
                    MyPanel1.Controls.Add(newControl);   //this will raise MyControl::pPanel_ControlAdded
                }
            }
        
        
        class MyControl : Control
        {
    
            //// for control added to Form
             Myform pForm;
             public MyControl(MyForm ff)
             {
               InitializeComponent();
               pForm=ff;
               pForm.ControlAdded+=new ControlEventHandler(pForm_ControlAdded);
             }
    
       ///now for control added to panel
            MyPanel pPanel;
            public MyControl(MyPanel pp)
            {
              InitializeComponent();
              pPanel=pp;
              pPanel.ControlAdded+=new ControlEventHandler(pPanel_ControlAdded);
            }
            
        }
