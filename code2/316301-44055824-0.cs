    	[TestMethod]
        public void GenerateTest()
        {
            RPGenerator gen = new RPGenerator();
            int maxRecursionLevel = 4;
            var intRes = gen.Generate<int>(maxRecursionLevel);            
            var stringArrayRes = gen.Generate<string[]>(maxRecursionLevel);
            var charArrayRes = gen.Generate<char[]>(maxRecursionLevel);
            var pocoRes = gen.Generate<SamplePocoClass>(maxRecursionLevel);
            var structRes = gen.Generate<SampleStruct>(maxRecursionLevel);
            var pocoArray = gen.Generate<SamplePocoClass[]>(maxRecursionLevel);
            var listRes = gen.Generate<List<SamplePocoClass>>(maxRecursionLevel);
            var dictRes = gen.Generate<Dictionary<string, List<List<SamplePocoClass>>>>(maxRecursionLevel);
            var parameterlessList = gen.Generate<List<Tuple<string, int>>>(maxRecursionLevel);
	        // Non-generic Generate
            var stringArrayRes = gen.Generate(typeof(string[]), maxRecursionLevel);
            var pocoRes = gen.Generate(typeof(SamplePocoClass), maxRecursionLevel);
            var structRes = gen.Generate(typeof(SampleStruct), maxRecursionLevel);
            Trace.WriteLine("-------------- TEST Results ------------------------");
            Trace.WriteLine(string.Format("TotalCountOfGeneratedObjects {0}", gen.TotalCountOfGeneratedObjects));
            Trace.WriteLine(string.Format("Generating errors            {0}", gen.Errors.Count));
        }
