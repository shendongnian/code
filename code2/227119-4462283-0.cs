    // Your sample control
    public class MyUserControl : Control
    {
        public event EventHandler<EventArgs> INeedData;
        public Data Data {get; set;}
        private class DoSomething()
        {
            if(INeedData!=null) INeedData(this,null);
        }
    }
    
    ...
    
    // Your Form, in the case that the control isn't already added.
    var _myUserControl = new MyUserControl();
    private void Form1_Load(object sender, EventArgs e)
    {
        _myUserControl.INeedData += new EventHandler<EventArgs>(MyUserControl_INeedData);
        this.Controls.Add(myUserControl);
    }
    
    void MyUserControl_INeedData(object sender, EventArgs e)
    {
        _myUserControl.Data = SomeData;
    }
