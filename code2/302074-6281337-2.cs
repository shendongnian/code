    void MyAction() { this.Bar(); }
    Action DelegateCache = null;
    ...
    for(i = 0; i < 10; ++i)
    {
        if (this.DelegateCache == null) this.DelegateCache = new Action ( this.MyAction )
        M(this.DelegateCache);
    }
