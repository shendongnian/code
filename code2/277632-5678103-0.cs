    using System;
    
    public class Example
    {
       public static void Main()
       {
          int value = -16;
          Byte[] bytes = BitConverter.GetBytes(value); 
    
          // Convert bytes back to Int32.
          int intValue = BitConverter.ToInt32(bytes, 0);
          Console.WriteLine("{0} = {1}: {2}", 
                            value, intValue, 
                            value.Equals(intValue) ? "Round-trips" : "Does not round-trip");
          // Convert bytes to UInt32.
          uint uintValue = BitConverter.ToUInt32(bytes, 0);
          Console.WriteLine("{0} = {1}: {2}", value, uintValue, 
                            value.Equals(uintValue) ? "Round-trips" : "Does not round-trip");
       }
    }
    
    byte[] bytes = { 0, 0, 0, 25 };
    
    // If the system architecture is little-endian (that is, little end first),
    // reverse the byte array.
    if (BitConverter.IsLittleEndian)
        Array.Reverse(bytes);
    
    int i = BitConverter.ToInt32(bytes, 0);
    Console.WriteLine("int: {0}", i);
