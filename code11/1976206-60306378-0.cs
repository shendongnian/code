    public interface IntermediateInterface<T> : IEquatable<T>
        where T : IntermediateInterface<T>
    {
        int Id { get; set; }
        bool IEquatable<T>.Equals(T other)
        {
            return Id == other?.Id;
        }
    }
    public class ActualType : IntermediateInterface<ActualType> {
        public int Id { get; set; }
    }
