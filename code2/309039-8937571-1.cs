            MyClass some_object = new MyClass() { PropA = "A", PropB = "B", PropC = "C" };
            JObject json = JObject.FromObject(some_object);
            foreach (JProperty property in json.Properties())
                Console.WriteLine(property.Name + " - " + property.Value);
            
            Console.ReadLine();
