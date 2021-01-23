    public struct Vector<T>
    {
        public readonly int Dimensions;
        public readonly T[] Elements;
        public Vector(Vector<T> source)
        {
            Dimensions = source.Dimensions;
            Elements = source.Elements != null ?
                (T[])source.Elements.Clone()
                : null;
        }
        public Vector<T> Clone()
        {
            return new Vector<T>(this);
        }
    
        // etc...
    }
