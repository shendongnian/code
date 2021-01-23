     [Serializable]
        public abstract class BaseMessage
        {
            public byte[] ToBinary()
            {
                BinaryFormatter bf = new BinaryFormatter();
                byte[] output = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Position = 0;
                    bf.Serialize(ms, this);
                    output = ms.GetBuffer();
                }
                return output;
            }
    
            public static T FromMessage<T>(CloudQueueMessage m)
            {
                byte[] buffer = m.AsBytes;
                T returnValue = default(T);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    ms.Position = 0;
                    BinaryFormatter bf = new BinaryFormatter();
                    returnValue = (T)bf.Deserialize(ms);
                }
                return returnValue;
            }
        }
