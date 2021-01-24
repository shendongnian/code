    public abstract class WebMethodBase<TInput, TOutput> : Base, IWebMethodBase<TInput, TOutput>
        where TInput : Request
        where TOutput : Response
    {
        public abstract TOutput Execute();
    
        protected TInput Input { get; set; }
    
        public WebMethodBase(TInput input)
        {
            Input = input;
        }
    }
