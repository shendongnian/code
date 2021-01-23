    // original method
    ...
    var x = FindFirst()
    ...
    
    // separate method
    public Tuple<int,int,int> FindFirst()
    {
        for (int I = 0; I < 10; I++)
        {
            for (int A = 0; A < 10; A++)
            {
                for (int B = 0; B < 10; B++)
                {
                    if (something)
                        return Tuple.Create(I,A,B);
                }
            }    
        }
        return null;
    }
