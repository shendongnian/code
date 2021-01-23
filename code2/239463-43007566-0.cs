    /// <summary>
    /// support class for DistinctKeepOrder extension
    /// </summary>
    public class Vector3DWithOrder
    {
        public int Order { get; private set; }
        public Vector3D Vector { get; private set; }
        public Vector3DWithOrder(Vector3D v, int order)
        {
            Vector = v;
            Order = order;
        }
    }
    
    public class Vector3DWithOrderEqualityComparer : IEqualityComparer<Vector3DWithOrder>
    {
        Vector3DEqualityComparer cmp;
    
        public Vector3DWithOrderEqualityComparer(Vector3DEqualityComparer _cmp)
        {
            cmp = _cmp;
        }
    
        public bool Equals(Vector3DWithOrder x, Vector3DWithOrder y)
        {
            return cmp.Equals(x.Vector, y.Vector);
        }
    
        public int GetHashCode(Vector3DWithOrder obj)
        {
            return cmp.GetHashCode(obj.Vector);
        }
    }
