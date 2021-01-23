     class MyClass {
        class Container<T>
        {
            public T Value { get; set; }
        }
        bool valSet;
        object val; 
        public T GetValue<T> () { 
            if (!valSet)
            {
                val = new Container<T>{Value =  (T)Convert.ChangeType(DatabaseValue, typeof(T))};
                valSet = true;
            }
            return ((Container<T>)val).Value;
        }
        public string DatabaseValue { get; set; }
     }
