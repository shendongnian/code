    public interface IVector<T, TScalar>
        where T : IVector<T, TScalar>
    {
        T Add(T addend);
    }
    public struct Vector3f : IVector<Vector3f, float>
    {
        public Vector3f Add(Vector3f addend)
        {
        }
    } 
    
