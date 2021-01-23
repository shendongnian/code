    public MyUserControl : IMyView
    {
        public static readonly DependencyProperty ThisProperty = 
             DependencyProperty.Register("This", typeof(IMyView), typeof(MyUserControl)); 
    
        public MyUserControl() 
        {
           SetValue(ThisProperty, this);
        } 
        public IMyView This { get { return GetValue(ThisProperty); } set { /* do nothing */ } } 
    }
