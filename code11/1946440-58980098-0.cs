    public interface IThing
    {
        string CommonProperty { get; }
        string Transform();
    }
    public class FirstThing : IThing
    {
        public string CommonProperty { get; }
        public string Transform() => this.CommonProperty + this.FirstParticularProperty;
        public string FirstParticularProperty { get; }
    }
    public class SecondThing : IThing
    {
        public string CommonProperty { get; }
        public string Transform() => this.CommonProperty + this.SecondParticularProperty;
        public string SecondParticularProperty { get; }
    }
