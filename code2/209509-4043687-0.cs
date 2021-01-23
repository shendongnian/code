       public struct TwentyBitInt
       {
          private const int mask = 0x08FF;
          private int val;
          private bool isDef;
    
    
          private TwentyBitInt(int value)
          {
             val = value & mask;
             isDef = true;
          }
          public static TwentyBitInt Make(int value) 
          { return new TwentyBitInt(value); }
    
          public int Value { get { return val; } }
          public bool HasValue { get { return isDef; } }
    
          public static TwentyBitInt Null = new TwentyBitInt();
    
          // etc.
        }
