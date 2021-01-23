    class StringSerializer : ITypeSerializer<string>
    {
        // implicit implementation of ITypeSerializer<string>
        public void Write(BinaryWriter writer, string obj)
        {
            // provide core implementation here
        }
        public string Read(BinaryReader reader)
        {
            // provide core implementation here
        }
        // explicit implementation of ITypeSerializer
        void ITypeSerializer.Write(BinaryWriter writer, object obj)
        {
            if (!(obj is string)) throw new ArgumentException("obj");
            this.Write(writer, (string)obj);
        }
        object ITypeSerializer.Read(BinaryReader reader)
        {
            return this.Read(reader);
        }
    }
