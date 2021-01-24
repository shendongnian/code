    public abstract class SampleA
    {
        // no setter -> cant be changed after initialization
        public abstract string PropertyA { get; } 
        // protected setter -> can only be changed from inside SampleA or Sample
        public abstract string PropertyB { get; protected set; } 
    }
    public class Sample : SampleA
    {
        public override string PropertyA { get; } = "override";
        public override string PropertyB { get; protected set; } = "override";
    }
