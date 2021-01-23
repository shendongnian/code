    public void Do(T val)
        {
            Val = val;
            MainClass.Print(Val);
        }
    
    and in you main method you have:
    
    test.Do();  //no parameter provided.
