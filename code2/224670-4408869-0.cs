            var template = Activator.CreateInstance<SimpleTemplate>();
            var session = new TextTemplatingSession();
            session["namespacename"] = "MyNamespace";
            session["classname"] = "MyClass";
            var properties = new List<CustomProperty>
            {
               new CustomProperty{ Name = "FirstProperty", ValueType = typeof(Int32) }
            };
            session["properties"] = properties;
            template.Session = session;
            template.Initialize();
