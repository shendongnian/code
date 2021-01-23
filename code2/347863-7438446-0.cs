    public delegate void MyDelegate(void);
    
    void MyMethod()
    {
      do stuff;
      this.Dispatcher.BeginInvoke(new MyDelegate(MyMethod), null);
    }
