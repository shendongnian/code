            var o1 = new SomeObject() { spec = new List<KeyValuePair<string, object>>() };
            o1.spec.Add(new KeyValuePair<string, object>("test with spaces", 10));
            var r1 = Newtonsoft.Json.JsonConvert.SerializeObject(o1);
            Console.WriteLine(r1);
            var o2 = Newtonsoft.Json.JsonConvert.DeserializeObject<SomeObject>(r1);
            var r2 = Newtonsoft.Json.JsonConvert.SerializeObject(o2);
            Console.WriteLine(r2);
