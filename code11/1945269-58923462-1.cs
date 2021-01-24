    /// <summary>
        /// Packet with image
        /// </summary>
        public class ImagePacket
        {
            public string hash { get; set; } = string.Empty;
            public int len { get; set; } = 0;
            public string image { get; set; } = string.Empty;
            public ImagePacket() { }
            public ImagePacket(byte[] img_sources)
            {
                hash = StringHash(img_sources);
                len = img_sources.Length;
                image = EncodeBytes(img_sources);
            }
            public byte[] GetRawData()
            {
                byte[] data = DecodeBytes(image);
                if(data.Length != len) throw new Exception("Error data len");
                if(!StringHash(data).Equals(hash)) throw new Exception("Error hash");
                return data;
            }
        }
