    [StructLayout(LayoutKind.Sequential), Serializable]
    public struct ListOfObjects
    {
        public int id;
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
    }
