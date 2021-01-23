    public sealed class ProjectionComparer<TValue, TProjection> : IEqualityComparer<TValue>
        {
            readonly Func<TValue, TProjection> _projection;
    
            public ProjectionComparer(Func<TValue, TProjection> projection)
            {
                projection.AssertParameterNotNull("projection");
                _projection = projection;
            }
    
            bool IEqualityComparer<TValue>.Equals(TValue x, TValue y)
            {
                var projectedX = _projection(x);
                var projectedY = _projection(y);
    
                return projectedX.Equals(projectedY);
            }
    
            int IEqualityComparer<TValue>.GetHashCode(TValue obj)
            {
                var projectedObj = _projection(obj);
                return projectedObj.GetHashCode();
            }
        }
