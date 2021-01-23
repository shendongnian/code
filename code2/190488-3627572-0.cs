    public class Generic_Element { }
    public class Generic_Visit<E>
    {
        public E Element { get; set; }
    }
    /// <summary>Collection of Visits</summary>
    public class Generic_Route<V>
    {
        public List<V> Visits { get; set; }
        public Double Distance { get; set; }
    }
    /// <summary>Collection of Routes</summary>
    public class Generic_Solution<R, V>
        where R : Generic_Route<V>
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
    public class Generic_Tsp_Element : Generic_Element
    {
    }
    /// <summary>Visit to a Generic_Element</summary>
    public class Generic_Tsp_Visit<E> : Generic_Visit<E>
    {
        public Double Time { get; set; }
    }
    /// <summary>Collection of Visits</summary>
    public class Generic_Tsp_Route<V, E> : Generic_Route<V>
        where V : Generic_Tsp_Visit<E>
    {
        public Double Time
        {
            get
            {
                return this.Visits.Select(v => v.Time).Sum();
            }
        }
    }
    /// <summary>Collection of Routes</summary>
    public class Generic_Tsp_Solution<R, V, E> : Generic_Solution<R, V>
        where R : Generic_Tsp_Route<V, E>
        where V : Generic_Tsp_Visit<E>
    {
        public Double Time
        {
            get
            {
                return this.Routes.Select(r => r.Time).Sum();
            }
        }
    }
    public class Concrete_Tsp_Element : Generic_Tsp_Element { }
    public class Concrete_Tsp_Visit : Generic_Tsp_Visit<Concrete_Tsp_Element> { }
    public class Concrete_Tsp_Route : Generic_Tsp_Route<Concrete_Tsp_Visit, Concrete_Tsp_Element> { }
    public class Concrete_Tsp_Solution : Generic_Tsp_Solution<Concrete_Tsp_Route, Concrete_Tsp_Visit, Concrete_Tsp_Element> { }
    public class Generic_Vrp_Element : Generic_Element
    {
    }
    /// <summary>Visit to a Generic_Element</summary>
    public class Generic_Vrp_Visit<V, E> : Generic_Visit<E>
    {
        public Double Capacity { get; set; }
    }
    /// <summary>Collection of Visits</summary>
    public class Generic_Vrp_Route<R, V, E> : Generic_Route<V>
        where V : Generic_Vrp_Visit<V, E>
    {
        public Double Capacity
        {
            get
            {
                return this.Visits.Select(v => v.Capacity).Sum();
            }
        }
    }
    /// <summary>Collection of Routes</summary>
    public class Generic_Vrp_Solution<S, R, V, E> : Generic_Solution<R, V>
        where R : Generic_Vrp_Route<R, V, E>
        where V : Generic_Vrp_Visit<V, E>
    {
        public Double Capacity
        {
            get
            {
                return this.Routes.Select(r => r.Capacity).Sum();
            }
        }
    }
    public class Concrete_Vrp_Element : Generic_Vrp_Element { }
    public class Concrete_Vrp_Visit : Generic_Vrp_Visit<Concrete_Vrp_Visit, Concrete_Vrp_Element> { }
    public class Concrete_Vrp_Route : Generic_Vrp_Route<Concrete_Vrp_Route, Concrete_Vrp_Visit, Concrete_Vrp_Element> { }
    public class Concrete_Vrp_Solution : Generic_Vrp_Solution<Concrete_Vrp_Solution, Concrete_Vrp_Route, Concrete_Vrp_Visit, Concrete_Vrp_Element> { }
