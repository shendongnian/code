    public sealed class IntArrayKey
    {
        public IntArrayKey(int[] array)
        {
            Array     = array;
            _hashCode = hashCode();
        }
        public int[] Array { get; }
        public override int GetHashCode()
        {
            return _hashCode;
        }
        int hashCode()
        {
            int result = 17;
            unchecked
            {
                foreach (var i in Array)
                {
                    result = result * 23 + i;
                }
            }
            return result;
        }
        readonly int _hashCode;
    }
