    public class Generic_Element<E>
        where E : Generic_Element<E>
    {
    }
    
    /// <summary>Visit to a Generic_Element</summary>
    public class Generic_Visit<V, E>
        where V : Generic_Visit<V, E>
        where E : Generic_Element<E>
    {
        public E Element { get; set; }
    }
    
    /// <summary>Collection of Visits</summary>
    public class Generic_Route<R, V, E>
        where R : Generic_Route<R, V, E>
        where V : Generic_Visit<V, E>
        where E : Generic_Element<E>
    {
        public List<V> Visits { get; set; }
        public Double Distance { get; set; }
    }
    
    /// <summary>Collection of Routes</summary>
    public class Generic_Solution<S, R, V, E>
        where S : Generic_Solution<S, R, V, E>
        where R : Generic_Route<R, V, E>
        where V : Generic_Visit<V, E>
        where E : Generic_Element<E>
    {
        public List<R> Routes { get; set; }
    
        public Double Distance
        {
            get
            {
                return this.Routes.Select(r => r.Distance).Sum();
            }
        }
    }
