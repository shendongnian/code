            dynamic CreateTypeFrom()
            {
                var assembly = typeof(string).Assembly;
                return assembly.CreateInstance("System.Version", true, BindingFlags.CreateInstance, null, new object[] { 1, 2, 3, 4 }, null, null);
            }
    
            [TestMethod]
            public void Test()
            {
                var t = CreateTypeFrom();
                int major = t.Major;
                Console.WriteLine(major);
            }
