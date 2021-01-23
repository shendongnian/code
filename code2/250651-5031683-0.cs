    public class PacketTransit
    {
        public static void SendPacket(TcpClient C, object Packet)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(Packet.GetType());
            xml.Serialize(ms, Packet);
            ms.Position = 0;
            byte[] b = ms.GetBuffer();
            ms.Dispose();
            byte [] sizePacket = BitConverter.GetBytes(b.Length);
            // Send the 4-byte size packet first.
            C.Client.Send(sizePacket, sizePacket.Length, SocketFlags.None);
            C.Client.Send(b, b.Length, SocketFlags.None);
        }
        /// The string is the XML file that needs to be converted.
        public static string ReceivePacket(TcpClient C, Type PacketType)
        {
            byte [] FirstTen = new byte[1024];
            int size = 0;
            byte[] sizePacket = BitConverter.GetBytes(size);
            // Get the size packet
            int sp = C.Client.Receive(sizePacket, sizePacket.Length, SocketFlags.None);
            if (sp <= 0) return "";
            size = BitConverter.ToInt32(sizePacket, 0);
            // read until "size" is met
            StringBuilder sb = new StringBuilder();
            while (size > 0)
            {
                byte[] b = new byte[1024];
                int x = size;
                if (x > 1024) x = 1024;
                int r = C.Client.Receive(b, x, SocketFlags.None);
                size -= r;
                sb.Append(UTF8Encoding.UTF8.GetString(b));
            }
            return sb.ToString();
        }
        /// The XML data that needs to be converted back to the appropriate type.
        public static object Decode(string PacketData, Type PacketType)
        {
            MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(PacketData));
            XmlSerializer xml = new XmlSerializer(PacketType);
            object obj = xml.Deserialize(ms);
            ms.Dispose();
            return obj;
        }
        public static RequestPacket GetRequestPacket(TcpClient C)
        {
            string str = ReceivePacket(C, typeof(RequestPacket));
            
            if (str == "") return new RequestPacket();
            RequestPacket req = (RequestPacket) Decode(str, typeof(RequestPacket));
            return req;
        }
        public static ResponsePacket GetResponsePacket(TcpClient C)
        {
            string str = ReceivePacket(C, typeof(ResponsePacket));
            if (str == "") return new ResponsePacket();
            ResponsePacket res = (ResponsePacket)Decode(str, typeof(ResponsePacket));
            return res;
        }
    }
To use this class, I simply need to call PacketTransit.SendPacket(myTcpClient, SomePacket) to send any given XML-Serializable object. I can then use PacketTransit.GetResponsePacket or PacketTransit.GetRequestPacket to receive it at the other end. 
