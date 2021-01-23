    using System.Collections;
    byte[] bytes = Encoding.ASCII.GetBytes(513.ToString());
    BitArray bits = new BitArray(bytes);
    int ndx = 9; //or whatever ndx you actually care about
    if (bits[ndx] == true)
    {
         Console.WriteLine("Bit at index {0} is on!", ndx);
    }
