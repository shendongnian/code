    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct tBowler_Rec
    {
        public tGender gender;
        public byte bowler_num;
        [MarshalAs(UnmanagedType.AnsiBStr)]
        public string name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public char[] initials;
