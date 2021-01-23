    public interface IPipeline
    {
        void AddLast(IPipelineHandler handler);
        void AddFirst(IPipelineHandler handler);
        
        void Invoke(IPipelineContext context);
    }
    
    public interface IPipelineContext
    {
       Form SourceForm {get; }
    
       // The result that the pipeline should produce.  (change from object to a specific type)
       object Result {get; }
    
       //and other properties that each handler will need.
    }
    public interface IPipelineHandler
    {
        string Name {get; }
        void Process(IPipelineContext context);
    }
