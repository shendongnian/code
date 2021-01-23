    public abstract class MappedTo<T, TConverter>
    {
        public MappedTo()
        {
            Mapper.CreateMap(GetType(), typeof(T)).ConvertUsing(typeof(TConverter));
        }
        public T Convert()
        {
            return (T)Mapper.Map(this, this.GetType(), typeof(T));
        }
    }
