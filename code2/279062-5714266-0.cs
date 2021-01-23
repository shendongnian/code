    public Entity Copy()
            {
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
    
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                bFormatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                IEntityForm entity= (IEntityForm)bFormatter.Deserialize(memoryStream);
                return entity;
            }
