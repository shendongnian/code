    public abstract class MappedTo<T>
    {
        public MappedTo()
        {
            Mapper.CreateMap(GetType(), typeof(T));
        }
    
        public T Convert()
        {
            return (T)Mapper.Map(this, this.GetType(), typeof(T));
        }
    }
