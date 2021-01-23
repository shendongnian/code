    public class MyEventArg
    {
        int _param1;
        string _param2;
        //you can add more param
        public MyEventArg(int _param1,string _param2)
        {
            this._param1 = _param1;
            this._param2 = _param2;
        }
    }
    
    public delegate void MyButtonClickHandler(object sender, MyEventArg e)
    public class MyButton:Control
    {
         public event MyButtonClickHandler OnMyClick;
         //You can raise your event here
	 protected override void OnClick(EventArgs e)
	 {
               MyEventArg e = new MyEventArg(1,"a");//just sample data here
               this.OnMyClick(this,e);
         }
    }
