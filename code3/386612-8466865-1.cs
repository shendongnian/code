    public interface IProcess
    {
        int ProcessItem(string workType);
    }
    
    internal interface ITryProcess
    {
        bool TryProcessItem(string workType, out int result);
    }
    
    public class ProcessImplementation1 : ITryProcess
    {
        public bool TryProcessItem(string workType, out int result)
        {
            result = -1;
            return false;
        }
    }
    
    public class ProcessImplementation : IProcess
    {
        public int ProcessItem(string workType)
        {
            var implementations = new List<ITryProcess>();
            implementations.Add(new ProcessImplementation1());
            // ...
            int processId = -1;
            foreach (ITryProcess implementation in implementations)
            {
                if (implementation.TryProcessItem(workType, out processId))
                {
                    break;
                }
            }
            if (processId < 0)
            {
                throw new InvalidOperationException("Unable to process.");
            }
            return processId;
        }
    }
