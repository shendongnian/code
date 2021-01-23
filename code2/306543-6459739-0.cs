    public class FooSettings
    {
        public int FooNumber { get; set; }
        public string FooString { get; set; }
    }
    public class BarSettings
    {
        public int BarNumber { get; set; }
        public string BarString { get; set; }
    }
    public interface IProcessor
    {
        void Process();
    }
    public class FooProcessor : IProcessor
    {
        public FooProcessor(FooSettings settings) { }
        public void Process() { }
    }
    public class BarProcessor : IProcessor
    {
        public BarProcessor(BarSettings settings) { }
        public void Process() { }
    }
    public interface IProcessorFactory
    {
        IProcessor GetProcessor(object settings);
    }
    public interface IProcessorConsumer { }
    public class ProcessorConsumer : IProcessorConsumer
    {
        private IProcessorFactory _processorFactory;
        private object _settings;
        public ProcessorConsumer(IProcessorFactory processorFactory, object settings)
        {
            _processorFactory = processorFactory;
            _settings = settings;
        }
        public void MyLogic()
        {
            IProcessor processor = _processorFactory.GetProcessor(_settings);
            processor.Process();
        }
    }
    public class ExampleProcessorFactory : IProcessorFactory
    {
        public IProcessor GetProcessor(object settings)
        {
            IProcessor p = null;
            if (settings is BarSettings)
            {
                p = new BarProcessor(settings as BarSettings);
            }
            else if (settings is FooSettings)
            {
                p = new FooProcessor(settings as FooSettings);
            }
            return p;
        }
    }
