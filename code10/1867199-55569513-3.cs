    public readonly struct ReadonlyStruct
    {
       public int First { get; }
       public int Second { get; }
       public ReadonlyStruct(int first, int second)
       {
          First = first;
          Second = second;
       }
    }
    
    ...
    public ReadonlyStruct ViaReadonlyStruct()
    {
       return new ReadonlyStruct(1, 2);
    }
    
    ...
    var readonlyStruct = ViaReadonlyStruct();
    Console.WriteLine($"{readonlyStruct.First}, {readonlyStruct.Second}");
