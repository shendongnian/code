        using System.IO;
        using System.Runtime.Serialization.Formatters.Binary;
        public class Message : ISerializable
        {
            DateTime timestamp;
            byte type;
            string message;
        }
        public byte[] BuildBuffer(Message input)
        {
            // Serialize the message
            Stream s = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(s, input);
            buffer = s.ToArray();
            return buffer;
        }
        public Message BuildMessage(byte[] input)
        {
            Stream s = new MemoryStream(input);
            s.Position = 0;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return (Message)binaryFormatter.Deserialize(s);
        }
