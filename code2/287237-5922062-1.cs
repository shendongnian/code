    abstract class A
    {
        static Dictionary<Type, int> all_x;
        protected int X {
            get { return all_x[GetType()]; }
            set { all_x[GetType()] = value; }
        }
    }
