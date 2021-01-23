    private class base_when_processed_audio_is_returned<TSutFactory>
        where TSutFactory : ISutFactory<IAudioProcessor>, new()
    {
        static IAudioProcessor Sut = new TSutFactory().CreateSut();
        protected static Context _ = new Context();
    
        Establish context = () => _.Original = Substitute.For<IEnumerable<ISample>>();
    
        public Because of = () => Sut.Process(_.Original);
    
        public It should_not_have_enumerated_the_original_samples = () =>
        {
            _.Original.DidNotReceive().GetEnumerator();
            ((IEnumerable)_.Original).DidNotReceive().GetEnumerator();
        };
    }
    public class when_processed_audio_is_returned_from_AudioProcessorImpl1Factory()
      : base_when_processed_audio_is_returned<AudioProcessorImpl1Factory>
    {}
    public class when_processed_audio_is_returned_from_AudioProcessorImpl2Factory()
      : base_when_processed_audio_is_returned<AudioProcessorImpl2Factory>
    {}
