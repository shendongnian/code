    private Expression<Func<double, double>> myFunc;
    private Func<double, double> cachedDelegate; 
    public void SetFunc(Expression<Func<double,double>> newFunc)
    {
        this.myFunc = newFunc;
        this.cachedDelegate = null;
    }
    public double ExecFunc(double x)
    {
        if (this.myFunc != null)
        {
            if (this.cachedDelegate != null)
            {
                return this.cachedDelegate(x);
            }
            else
            {
                this.cachedDelegate = this.myFunc.Compile();
                return this.cachedDelegate(x);
            }
        }
        return 0.0;
    }
    public string GetFuncText()
    {
        if (this.myFunc != null)
        {
            return this.myFunc.ToString();
        }
        return "";
    }
