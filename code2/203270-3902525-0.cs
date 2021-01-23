    class CustomClass<T>
    {
        public CustomClass(T defaultValue)
        {
            init((dynamic)defaultValue);
        }
        private void init(bool defaultValue) { Console.WriteLine("bool"); }
        private void init(int defaultValue) { Console.WriteLine("int"); }
        private void init(object defaultValue) {
            Console.WriteLine("fallback for all other types that don’t have "+
                              "a more specific init()");
        }
    }
