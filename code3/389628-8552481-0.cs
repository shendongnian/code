        public BaseClass DeSerializeAnObject(BaseClass bc)
        {
            if (bc == null) return bc;
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, bc);
                stream.Seek(0, SeekOrigin.Begin);
                return (BaseClass)formatter.Deserialize(stream);
            }
        }
  
