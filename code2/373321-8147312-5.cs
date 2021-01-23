    [Subject("Audio Processor Impl 1")]
    public class when_impl1_processes_audio : AudioProcessorContext<AudioProcessorImpl1Factory>
    {
        Because of = () => Sut.Process(_.Original);
        Behaves_like<DeferredExecutionProcessor> specs;
    }
    [Subject("Audio Processor Impl 2")]
    public class when_impl2_processes_audio : AudioProcessorContext<AudioProcessorImpl2Factory>
    {
        Because of = () => Sut.Process(_.Original);
        Behaves_like<DeferredExecutionProcessor> specs;
    }
    [Subject("Audio Processor Impl 3")]
    public class when_impl3_processes_audio : AudioProcessorContext<AudioProcessorImpl3Factory>
    {
        Because of = () => Sut.Process(_.Original);
        Behaves_like<DeferredExecutionProcessor> specs;
    }
