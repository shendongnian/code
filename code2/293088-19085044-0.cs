    public class ModelBase
    {
        public T ShallowCopy<T>() where T : ModelBase
        {
            return (T)(MemberwiseClone());
        }
    }
