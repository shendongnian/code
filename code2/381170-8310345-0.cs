    public MyModule : NancyModule
    {
        public MyModule()
        {  
            Get["/item/detail/{id}"] = parameters => {
                return new Detail(parameters.id).AsXml(); //this is pseudocode offcourse!
            };
        }
    }
