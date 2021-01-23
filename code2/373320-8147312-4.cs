    public abstract class AudioProcessorContext<TSutFactory>
        where TSutFactory : ISutFactory<IAudioProcessor>, new()
    {
        // I don't know Behaves_like works with field initializers
        Establish context = () => 
        {
            Sut = new TSutFactory().CreateSut();
            _ = new Context();
            _.Original = Substitute.For<IEnumerable<ISample>>();
        }
        protected static IAudioProcessor Sut;
        protected static Context _;
    }
