        public class M1
        {
            public string Name { get; set; }
        }
        public class M2
        {
            public string Name { get; set; }
        }
        [Test]
        public void Cast()
        {
            object source = new List<M1> {new M1 {Name = "o"}};
            object target = new List<M2>();
            var targetArgumentType = target.GetType().GetGenericArguments()[0];
            var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(targetArgumentType));
            var add = list.GetType().GetMethod("Add");
            foreach (var o in source as IEnumerable)
            {
                var t = Activator.CreateInstance(targetArgumentType);
                add.Invoke(list, new[] { t.InjectFrom(o) });
            }
            target = list;
            Assert.AreEqual("o", (target as List<M2>).First().Name);
        }
