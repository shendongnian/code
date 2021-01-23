    public static MapProjection<T1> Map<T1>(this IEnumerable<T1> list, IMappingEngine engine)
    {
        return new MapProjection<T1>(list, engine);
    }
    public class MapProjection<T1>
    {
        private readonly IEnumerable<T1> list;
        private readonly IMappingEngine engine;
        internal MapProjection( IEnumerable<T1> list, IMappingEngine engine)
        {this.list = list; this.engine = engine;}
        public IEnumerable<T2> To<T2>()
        {
            return list.Select(engine.Map<T1, T2>());
        }
    }
