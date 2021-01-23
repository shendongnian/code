        [TestMethod]
        public void TestWithStream()
        {
            var objects = Enumerable.Range(0, 1000000).Select(_ => new TestObject { TestProperty = Guid.NewGuid().ToString() }).ToList();
            Stopwatch w = Stopwatch.StartNew();
            for (int i = 0; i < objects.Count; ++i)
            {
                ObjectCopier.CloneWithStream(objects[i]);
            }
            Console.WriteLine(w.Elapsed);
        }
        [TestMethod]
        public void TestWithDeepClone()
        {
            var objects = Enumerable.Range(0, 1000000).Select(_ => new TestObject { TestProperty = Guid.NewGuid().ToString() }).ToList();
            Stopwatch w = Stopwatch.StartNew();
            for (int i = 0; i < objects.Count; ++i)
            {
                ObjectCopier.CloneWithDeepClone(objects[i]);
            }
            Console.WriteLine(w.Elapsed);
        }
        public static class ObjectCopier
        {
            public static T CloneWithStream<T>(T source)
            {
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", "source");
                }
                if (Object.ReferenceEquals(source, null))
                {
                    return default(T);
                }
                Stream stream = new MemoryStream();
                using (stream)
                {
                    Serializer.Serialize<T>(stream, source);
                    stream.Seek(0, SeekOrigin.Begin);
                    return Serializer.Deserialize<T>(stream);
                }
            }
            public static T CloneWithDeepClone<T>(T source)
            {
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", "source");
                }
                if (Object.ReferenceEquals(source, null))
                {
                    return default(T);
                }
                return Serializer.DeepClone(source);
            }
        }
