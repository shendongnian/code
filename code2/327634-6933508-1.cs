            public class JsonAttribute : Attribute
            {
              Dictionary<string, string> _nameValues = 
                  new Dictionary<string, string>();
              public JsonAttribute(string jsoninit)
              {
                var dictionary = new Dictionary<string, string>();
                dynamic obj = JsonConvert.DeserializeObject(jsoninit);
                foreach(var item in obj)
                  _nameValues[item.Name] = item.Value.Value;
              }
            }
    Which would then allow you to instantiate an attribute like so:
        [Json(@"{""key1"":""val1"", ""key2"":""val2""}")]
        public class Foo { ... }
    I know it's a little quote-happy, a lot more involved, but there you are.  Regardless, in this crazy dynamic world, knowing how to initialize objects with JSON isn't a bad skill to have in your back pocket.
