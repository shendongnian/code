    public class Processor
    {
        public event Func<ProcessingArgs, Task> Processing;
    
        public async Task<int?> ProcessAsync()
        {
            if (Processing?.GetInvocationList() is Delegate[] processors)
            {
                var args = new ProcessingArgs();
                foreach (Func<ProcessingArgs, Task> processor in processors)
                {
                    await processor(args);
                }
                return args.Result;
            }
            else return null;
        }
    }
