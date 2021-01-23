    public abstract class AudioProcessorContext<TSutFactory>
        where TSutFactory : ISutFactory<IAudioProcessor>, new()
    {
        Establish context = () => _.Original = Substitute.For<IEnumerable<ISample>>();
        Because of = () => Sut.Process(_.Original);
        Behaves_like<DeferredExecutionProcessor> specs;
        protected static IAudioProcessor Sut = new TSutFactory().CreateSut();
        protected static Context _ = new Context();
    }
