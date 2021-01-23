        class MyClass: MyBaseClass
        {
            Dictionary<string, object> dynamicProperties = new Dictionary<string, object>();
            public void AddProperty(string key, object value){
                dynamicProperties[key] = value;
            }
