    class BaseModel<T>
    {
        public virtual T[] Get()
        {
            // return array of T's
        }
        public virtual T Find(object param)
        {
            // return T based on param
        }
        public virtual T New()
        {
            // return a new instance of T
        }
    }
