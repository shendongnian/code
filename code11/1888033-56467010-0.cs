    private int GetPointerValue(Int32 baseAddress, int[] offsetArr)
    {
        var pointer = IntPtr.Add((IntPtr)vam.ReadInt32(baseAddress), offsetArr[0]);
        for (int i = 1; i < offsetArr.Length; i++)
        {
            pointer = IntPtr.Add((IntPtr)vam.ReadInt32(pointer), offsetArr[i]);
        }
        return vam.ReadInt32(pointer);
    }
    private var baseAddress = 0xEE231C;
    private var offsetArr = new int[]{ 0x30, 0x0, 0x1BC, 0x178, 0x0, 0x4 };
    Console.WriteLine("     value: " + GetPointerValue(baseAddress, offsetArr));
