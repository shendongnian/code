    public static int[] DoSomething<T> (T[] Input) where T : IWellKnown
    {
       int[] Output = new int[Input.Length];
    
       for (int i = 0;i < Input.Length;i++)
          Output[i] = Input[i].PropertyA+Input[i].PropertyB;
    
       return Output;
    }
