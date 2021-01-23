    public interface ITypeSerializer
    {
        void Write(BinaryWriter writer, object obj);
        object Read(BinaryReader reader);
    }
    public interface ITypeSerializer<T> : ITypeSerializer
    {
        void Write(BinaryWriter writer, T obj); 
        T Read(BinaryReader reader);
    }
