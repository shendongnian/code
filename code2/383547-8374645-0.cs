    public static byte[] BinarySerialize(Object obj)
            {
                byte[] serializedObject;
                MemoryStream ms = new MemoryStream();
                BinaryFormatter b = new BinaryFormatter();
                try
                {
                    b.Serialize(ms, obj);
                    ms.Seek(0, 0);
                    serializedObject = ms.ToArray();
                    ms.Close();
                    return serializedObject;
                }
                catch
                {
                    throw new SerializationException("Failed to serialize. Reason: ");
                }
    
            }
