    LargestPrimeNumber lpn = new LargestPrimeNumber();
    
    while(n < test)
    {
        if(lpn.IsPrime(n))
        {
           Console.WriteLine(n);
        }
    
        n++;
    }
