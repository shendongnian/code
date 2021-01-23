    public abstract class Primitive
    {
        internal static IPrimitiveIDGenerator Generator;
        protected Primitive()
        {
            Id = Generator.GetNext();
        }
        internal int Id { get; private set; }
    }
    public interface IPrimitiveIDGenerator
    {
        int GetNext();
    }
    public class PrimitiveIDGenerator : IPrimitiveIDGenerator
    {
        private int? _previousId;
        public int GetNext()
        {
            try
            {
                _previousId = checked(++_previousId) ?? 0;
                return _previousId.Value;
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Cannot instantiate more than (int.MaxValue) unique primitives.", ex);
            }
        }
    }
