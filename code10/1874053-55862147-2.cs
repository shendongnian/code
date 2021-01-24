    public abstract class SampleA
    {
        public abstract string PropertyA { get; } // no setter -> cant be changed after initialization
        public abstract string PropertyB { get; protected set; } // private setter -> can only be changed from inside SampleA or Sample
    }
    public class Sample : SampleA
    {
        public override string PropertyA { get; } = "override";
        public override string PropertyB { get; protected set; } = "override";
    }
