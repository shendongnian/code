      using System.Collections;
      using System.Linq;
      ...
      BitArray myBitArray = ...
      byte[] myByte = myBitArray
        .OfType<bool>()
        .Select((value, index) => new { // into chunks of size 8
           value,
           chunk = index / 8 })
        .GroupBy(item => item.chunk, item => item.value)
        .Select(chunk => chunk // Each byte representation
          .Reverse()           // should be reversed   
          .Aggregate(0, (s, bit) => (s << 1) | (bit ? 1 : 0)))
        .Select(item => (byte) item)
        .ToArray();
