    public class LambdaComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> equals;
        private readonly Func<T, int> getHashCode;
    
        public LambdaComparer(Func<T, T, bool> lambdaComparer) :
            this(lambdaComparer, o => o.GetHashCode())
        {
        }
    
        public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
        {
            if (lambdaComparer == null)
                throw new ArgumentNullException("lambdaComparer");
            if (lambdaHash == null)
                throw new ArgumentNullException("lambdaHash");
    
            equals = lambdaComparer;
    
            getHashCode = lambdaHash;
        }
    
        public bool Equals(T x, T y)
        {
            return equals(x, y);
        }
    
        public int GetHashCode(T obj)
        {
            return getHashCode(obj);
        }
    }
    File[] filesInA_butNotInB = filesA.Except(filesB, (a,b) => a.Name == b.Name).ToArray();
    File[] filesInBoth = filesA.Intersect(filesB, (a,b) => a.Name == b.Name).ToArray();
    File[] filesInBoth_butDifferentHash = FilesA.Intersect(filesB, (a,b) => a.Name == b.Name && a.HashCode != b.HashCode).ToArray();
