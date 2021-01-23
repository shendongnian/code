    public class Foo
    {
        private readonly IIndex<string, ITagProcessor> _tagProcessorIndex;
        public Foo(IIndex<string, ITagProvider> tagProcessorIndex)
        {
            _tagProcessorIndex = tagProcessorIndex;
        }
        public void Process(int unitId, Tag tag)
        {
            ITagProcessor processor;
            if(_tagProcessorIndex.TryGetValue(tag.Name, out processor))
            {
                var data = processor.Process(unitId, tag.Values);
                Trace.WriteLine("Tag <{0}> processed. # of IO Items => {1}".FormatWith(tag.Name, data.Count()));
            }
        }
    }
