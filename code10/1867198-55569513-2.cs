    public struct ClassicStruct
    {
       public int First { get; set; }
       public int Second { get; set; }
       public ClassicStruct(int first, int second)
       {
          First = first;
          Second = second;
       }
    }
    
    ...
    public ClassicStruct ViaClassicStruct()
    {
       return new ClassicStruct(1, 2);
    }
   
    ... 
    var classicStruct = ViaClassicStruct();
    Console.WriteLine($"{classicStruct.First}, {classicStruct.Second}");
