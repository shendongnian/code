      List<SampleClass> list = new List<SampleClass>();   
      Func<SampleClass, int> expr = (c) => c.SomeProperty;
      _HungerLevel = level;
      class SampleClass
      {
        public int SomeProperty { get; set; }
      }
