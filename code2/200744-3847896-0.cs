    public int myprop;
    public int MyProperty {get { return myprop;}}
    
    ... ...
    
    this.myprop = 30;
    
    ... ...
    if(this.MyProperty > 5)
       this.myprop = 40;
