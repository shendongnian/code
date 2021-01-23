    public MyClass
    {
        public static async MyClass CreateAsync(...)
        {
            MyClass x = new MyClass();
            await x.Initialize(...)
            return x;
        }
        
        // make sure no one but the Create function can call the constructor:
        private MyClass(){}
        private async Task Initialize(...)
        {
            // do the async things you wanted to do in your async constructor
        }
        
        public async Task<int> MyFunctionAsync(int a, int b)
        {
            return await OtherFunction(a, b);
        }
