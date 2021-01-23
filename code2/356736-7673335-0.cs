    static int Fib(int n)
    {
        double sqrt5 = Math.Sqrt(5);
        double p1 = (1 + sqrt5) / 2; 
        double p2 = -1 * (p1 - 1);          
            
        double n1 = 1.0;
        double n2 = 1.0;
        Parallel.For(0,n+1,(x)=>{
            n1*=p1;
            n2*=p2;
        });
        return (int)((n1-n2)/sqrt5);
    }
