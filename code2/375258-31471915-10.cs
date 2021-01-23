    public MyClass
    {
        public static async Task<MyClass> CreateAsync(...)
        {
            MyClass x = new MyClass();
            await x.InitializeAsync(...)
            return x;
        }
        
        // make sure no one but the Create function can call the constructor:
        private MyClass(){}
        private async Task InitializeAsync(...)
        {
            // do the async things you wanted to do in your async constructor
        }
        
        public async Task<int> OtherFunctionAsync(int a, int b)
        {
            return await ... // return something useful
        }
