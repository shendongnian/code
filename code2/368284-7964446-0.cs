    [Serializable]
    class PicInfo
    {
        public string fileName { get; set; }
        public string completeFileName { get; set; }
        public string filePath { get; set; }
        public byte[] hashValue { get; set; }
    
        public PicInfo()  { }
    }
    static class Program
    {
        static void Main()
        {
            List<PicInfo> pi = new List<PicInfo>();
            pi.Add(new PicInfo {fileName = "foo.bar", hashValue = new byte[] {1, 2, 3}});
    
            var ser = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                ser.Serialize(ms, pi);
                var bytes = ms.ToArray();
            }
        }
    }
