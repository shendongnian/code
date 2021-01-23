    static void Main(string[] args)
    {
        byte[] arr = new byte[] { 0x00, 0xFF, 0x02, 0xDA, 0xFF, 0x55, 0xFF, 0x04 };
        List<ArraySegment<byte>> retval = GetSubArrays(arr, 0xFF);
        // this also works (looks like LINQ):
        //List<ArraySegment<byte>> retval = arr.GetSubArrays(0xFF);
            
        byte[] buffer = new byte[retval.Select(x => x.Count).Max()];
        foreach (var x in retval)
        {
            Buffer.BlockCopy(x.Array, x.Offset, buffer, 0, x.Count);
            Console.WriteLine(String.Join(", ", buffer.Take(x.Count).Select(b => b.ToString("X2")).ToArray()));
        }
        Console.ReadLine();
    }
