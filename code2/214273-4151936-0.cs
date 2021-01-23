    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    class Foo
    {
        public string Name { get; set; }
        public bool ImAHappyCamper { get; set; }
        private class FooConverter : JavaScriptConverter
        {
            public override object Deserialize(System.Collections.Generic.IDictionary<string, object> dictionary, System.Type type, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override System.Collections.Generic.IEnumerable<System.Type> SupportedTypes
            {
                get { yield return typeof(Foo); }
            }
            public override System.Collections.Generic.IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                var data = new Dictionary<string, object>();
                Foo foo = (Foo)obj;
                if (foo.ImAHappyCamper) data.Add("isOk", foo.ImAHappyCamper);
                if(!string.IsNullOrEmpty(foo.Name)) data.Add("name", foo.Name);
                return data;
            }
        }
        private static JavaScriptSerializer serializer;
        public static JavaScriptSerializer Serializer {
            get {
                if(serializer == null) {
                    var tmp = new JavaScriptSerializer();
                    tmp.RegisterConverters(new [] {new FooConverter()});
                    serializer = tmp;
                }
                return serializer;
            }
        }
    }
    static class Program {
        static void Main()
        {
            var obj = new Foo { ImAHappyCamper = true, Name = "Fred" };
            string s = Foo.Serializer.Serialize(obj);
        }
    }
