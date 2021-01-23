    [TestFixture]
    public class InferredProtoPoc
    {
        [Test]
        public void UsageTest()
        {
            var model = TypeModel.Create();
            // Dynamically create the model for MyPoco
            AddProperties(model, typeof(MyPoco));
            // Display the Generated Schema of MyPoco
            Console.WriteLine(model.GetSchema(typeof(MyPoco)));
            var instance = new MyPoco
            {
                IntegerProperty = 42,
                StringProperty = "Foobar",
                Containers = new List<EmbeddedPoco>
                {
                    new EmbeddedPoco { Id = 12, Name = "MyFirstOne" },
                    new EmbeddedPoco { Id = 13, Name = "EmbeddedAgain" }
                }
            };
            var ms = new MemoryStream();
            model.Serialize(ms, instance);
            ms.Seek(0, SeekOrigin.Begin);
            var res = (MyPoco) model.Deserialize(ms, null, typeof(MyPoco));
            Assert.IsNotNull(res);
            Assert.AreEqual(42, res.IntegerProperty);
            Assert.AreEqual("Foobar", res.StringProperty);
            var list = res.Containers;
            Assert.IsNotNull(list);
            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(list.Any(x => x.Id == 12));
            Assert.IsTrue(list.Where(x => x.Id == 12).Any(x => x.Name == "MyFirstOne"));
            Assert.IsTrue(list.Any(x => x.Id == 13));
            Assert.IsTrue(list.Where(x => x.Id == 13).Any(x => x.Name == "EmbeddedAgain"));
        }
        private static void AddProperties(RuntimeTypeModel model, Type type)
        {
            var metaType = model.Add(type, true);
            foreach (var property in type.GetProperties().OrderBy(x => x.Name))
            {
                metaType.Add(property.Name);
                var propertyType = property.PropertyType;
                if (!IsBuiltinType(propertyType) &&
                    !model.IsDefined(propertyType) && 
                    propertyType.GetProperties().Length > 0)
                {
                    
                    AddProperties(model, propertyType);
                }
            }
        }
        private static bool IsBuiltinType(Type type)
        {
            return type.IsValueType || type == typeof (string);
        }
    }
    public class MyPoco
    {
        public int IntegerProperty { get; set; }
        public string StringProperty { get; set; }
        public List<EmbeddedPoco> Containers { get; set; }
    }
    public class EmbeddedPoco
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }
