    public void testMethod(int input)
    {
        int j = 0;
        int k = j;
        d1 = () => { j = 10; return j < input; };
        d2 = (x) => { return x == k; };
        System.Console.WriteLine("j = {0}", j);
    
        bool res = d1();
        System.Console.WriteLine("res={0}, j ={1}", res, j);
    
    }
