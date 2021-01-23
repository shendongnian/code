    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            foo = config["foo"];
            if (String.IsNullOrEmpty(foo))
            {
                // You can set a default value for foo
            }
    
            //remove foo from the config just like BufferedWebEventProvider with the other
            //attributes. Note that it doesn't matter if someone didn't proivde a foo attribute
            //because the NameValueCollection remains unchanged if you call its Remove method
            //and the name doesn't exist.
            config.Remove("foo");
    
            base.Initialize(name, config);
        }
