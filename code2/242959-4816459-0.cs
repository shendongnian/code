    MyControl ctrl1 = new MyControl();
    ctrl1.ID = "MyControlA";
    ctrl1.Text = "Some text";
    ViewState[ctrl1.ID] = ctrl1.Text;
    
    MyControl ctrl2 = new MyControl();
    ctrl2.ID = "MyControlB";
    ctrl2.Text = "Some other text";
    ViewState[ctrl2.ID] = ctrl2.Text; 
