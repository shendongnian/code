    using System;
    
    class Dirty<T>
    {
        T _Value;
        bool _IsDirty;
    
        public T Value
        {
            get { return _Value; }
            set
            {
                _IsDirty = true;
                _Value = value;
            }
        }
    
        public bool IsDirty
        {
            get { return _IsDirty; }
        }
    
        public Dirty(T initValue)
        {
            _Value = initValue;
        }
    }
    
    class Program
    {
        static Dirty<int> _Integer;
        static int Integer
        {
            get { return _Integer.Value; }
            set { _Integer.Value = value;  }
        }
    
        static void Main(string[] args)
        {
            _Integer = new Dirty<int>(10);
            Console.WriteLine("Dirty: {0}, value: {1}", _Integer.IsDirty, Integer);
            Integer = 15;
            Console.WriteLine("Dirty: {0}, value: {1}", _Integer.IsDirty, Integer);
        }
    }
