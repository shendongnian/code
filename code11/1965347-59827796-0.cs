      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      struct Data
      {
         public UInt32 dummy;
         public Single val;
      };
      static void Main(string[] args)
      {
         byte [] byteArray = File.ReadAllBytes("File.bin");
         ReadOnlySpan<Data> dataArray = MemoryMarshal.Cast<byte, Data>(new ReadOnlySpan<byte>(byteArray));
         Single prevVal=0;
         foreach( var v in dataArray) {
            if (prevVal!=0) {
               var diff = Math.Abs(v.val - prevVal) / prevVal;
               if (diff > 0.25)
                  Console.WriteLine("Bad!");
            }
            prevVal = v.val;
         }
      }
   }
It indeed works much faster than the original implementation.
