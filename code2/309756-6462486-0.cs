     class SomeFields { public int a; public int b; ... }
     
     var collection = new Dictionary<string, SomeFields>();
     collection.Add("name", new SomeFields() { a = 1, b = 2 });
     var fields = collection["name"];
