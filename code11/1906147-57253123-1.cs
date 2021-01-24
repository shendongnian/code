    public class TwoDimensionCompare<T> : IEqualityComparer<T[,]>
    {
        public bool Equals(T[,] x, T[,] y)
        {
            // fail fast if the sizes aren't the same
            if (y.GetLength(0) != x.GetLength(0)) return false;
            if (y.GetLength(1) != x.GetLength(1)) return false;
            // compare element by element
            for (int i = 0; i < y.GetLength(0); i++)
                for (int z = 0; z < y.GetLength(1); z++)
                    if (!EqualityComparer<T>.Default.Equals(x[i, z], y[i, z])) return false;
            return true;
        }
    
        public int GetHashCode(T[,] obj)
        {
            return obj.GetHashCode();
        }
    }
