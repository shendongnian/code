    services.AddTransient(typeof(IGetItems<,>), typeof(GetItems));
    
    class GetItems : IGetItems<GetResultsParms, GetResults> {}
    class Consumer {
        
        public Consumer( IGetItems<String,Int32> getter )
        {
            // ...
        }
    }
