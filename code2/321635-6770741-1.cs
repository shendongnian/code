    public class Processor
    {
        public Processor(IDep1 dependency1, IDep2 dependency2)
        {
            _dependency1 = dependency1;
            _dependency2 = dependency2;
        }
    
        IDep1 _dependency1;
        IDep2 _dependency2;
    
        public IEnumerable<int> Process(int input)
        {
            foreach(var element in dependency1.GetSomeList(input))
            {
                yield return dependency2.DoSomeProcessing(element);
            }
        }
    }
