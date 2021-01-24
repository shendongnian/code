    public interface IBool
    {
        bool IsTrue();
    }
    public struct True : IBool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsTrue()
        {
            return true;
        }
    }
    public struct False : IBool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsTrue()
        {
            return false;
        }
    }
