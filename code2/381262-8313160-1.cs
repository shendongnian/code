    public MyModule : NancyModule
    {
        public MyModule()
        {  
            Get["/stuff/{id}"] = parameters => {
                return new Stuff(parameters.id).AsJson();
            };
        }
    }
