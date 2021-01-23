    public class ProcessorImpl : IProcessor
    {
        // Either create them here or get them from some constructor injection or whatever.
        private readonly Type1Processor type1 = new Type1Processor(); 
        private readonly Type2Processor type2 = new Type2Processor(); 
        public ICollection<OutputEntity> Process(ICollection<InputEntity>> entities)
        {
            var type1Records = records.Where(x => x.SomeField== "Type1").ToList();
            var type2Records = records.Where(x => x.SomeField== "Type2").ToList();
            var result = new List<OutputEntity>();
            result.AddRange(type1.Process(type1Records));
            result.AddRange(type2.Process(type2Records));
            return result;
        }
    }
