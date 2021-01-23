    public void ApplyScale(int x, int Y, bool isHorizontal)
    {
        // Code 1
        if(isHorizontal)
        {
           forecast.Formula = Method1(X, Y);
        }
        else
        {
           forecast.Formula = Method2("Foo");
        }
        // Code 2
    }
