    [ProtoContract]
    public class PicInfo
    {
        [ProtoMember(1)]public string fileName { get; set; }
        [ProtoMember(2)]public string completeFileName { get; set; }
        [ProtoMember(3)]public string filePath { get; set; }
        [ProtoMember(4)]public byte[] hashValue { get; set; }
    
        public PicInfo()  { }
    }
    static class Program
    {
        static void Main()
        {
            List<PicInfo> pi = new List<PicInfo>();
            pi.Add(new PicInfo {fileName = "foo.bar", hashValue = new byte[] {1, 2, 3}});
    
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, pi);
                var bytes = ms.ToArray();
            }
        }
    }
