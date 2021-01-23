    public interface IProblem<T>
    {
        IList<T> Results { get; set; } // maybe even only a get; ?
    }
    public abstract class ProblemBase<T> : IProblem<T>
    {
        public IList<T> Results { get; set; }
    }
