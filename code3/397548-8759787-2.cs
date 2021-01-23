    public interface IVector<T, TScalar>
        where T : IVector<T, TScalar>
    {
        void Add(ref T addend);
    }
    public struct Vector3f : IVector<Vector3f, float>
    {
        public void Add(ref Vector3f addend)
        {
        }
    } 
