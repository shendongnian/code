<pre>
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public unsafe struct tBowler_Rec
    {
        public tGender gender;
        public byte bowler_num;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
        public byte[] name;
        ...
        public string Name
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                int ilen = name[0];
                for (int i = 1; i <= ilen; i++)
                    sb.Append(name[i]);
                return sb.ToString();
            }
        }</pre></code>
Vladimir was absolutely on the right track: the fundamental problem was that I needed to treat this Delphi array as a value type, not a C# (reference type) array.  The solution is "MarshalAs(UnmanagedType.ByValArray)"/
Thank you, all!
