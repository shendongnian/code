    using System.Collections;
    int originalInt = 7;
    byte[] bytes = BitConverter.GetBytes(originalInt);
    BitArray bits = new BitArray(bytes);
    int ndx = 9; //or whatever ndx you actually care about
    if (bits[ndx] == true)
    {
         Console.WriteLine("Bit at index {0} is on!", ndx);
    }
