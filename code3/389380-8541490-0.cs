    public int Multiplication(int x,int a,int b)
    {
        return this.Multiplication(x, a, b, (a, b) => a + b);
    }
    
    public int Multiplication(int x,int a,int b, Func<int, int, int> sumFunc)
    {
        return x * sumFunc(a, b);
    }
