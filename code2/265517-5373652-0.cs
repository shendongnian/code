    public class VXN_REQUEST 
    {
        private byte[] m_data;
        public const int Size = 8328;
        public VXN_REQUEST()
        {
            m_data = new byte[Size];
        }
        public static implicit operator byte[](VXN_REQUEST req)
        {
            return req.m_data;
        }
        public string DID
        {
            get { return Encoding.ASCII.GetString(m_data, 0, 33).Trim('\0'); }
        }
        public string MID
        {
            get { return Encoding.ASCII.GetString(m_data, 33, 33).Trim('\0'); }
        }
        public string TID
        {
            get { return Encoding.ASCII.GetString(m_data, 66, 33).Trim('\0'); }
        }
        public string ClientRef
        {
            get { return Encoding.ASCII.GetString(m_data, 99, 33).Trim('\0'); }
        }
        public string Payload
        {
            get { return Encoding.ASCII.GetString(m_data, 132, PayloadLength).Trim('\0'); }
        }
        public int PayloadLength
        {
            get { return BitConverter.ToInt32(m_data, 8324); }
        }
    }
