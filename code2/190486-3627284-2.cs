    public class Generic_Vrp_Element<E> : Generic_Element<E>
    where E : Generic_Vrp_Element<E>
    {
    }
    
    /// <summary>Visit to a Generic_Element</summary>
    public class Generic_Vrp_Visit<V, E> : Generic_Visit<V, E>
        where V : Generic_Vrp_Visit<V, E>
        where E : Generic_Vrp_Element<E>
    {
        public Double Capacity { get; set; }
    }
    
    /// <summary>Collection of Visits</summary>
    public class Generic_Vrp_Route<R, V, E> : Generic_Route<R, V, E>
        where R : Generic_Vrp_Route<R, V, E>
        where V : Generic_Vrp_Visit<V, E>
        where E : Generic_Vrp_Element<E>
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
    public class Generic_Vrp_Solution<S, R, V, E> : Generic_Solution<S, R, V, E>
        where S : Generic_Vrp_Solution<S, R, V, E>
        where R : Generic_Vrp_Route<R, V, E>
        where V : Generic_Vrp_Visit<V, E>
        where E : Generic_Vrp_Element<E>
    {
        public Double Capacity
        {
            get
            {
                return this.Routes.Select(r => r.Capacity).Sum();
            }
        }
    }
    
    public class Concrete_Vrp_Element : Generic_Vrp_Element<Concrete_Vrp_Element> { }
    
    public class Concrete_Vrp_Visit : Generic_Vrp_Visit<Concrete_Vrp_Visit, Concrete_Vrp_Element> { }
    
    public class Concrete_Vrp_Route : Generic_Vrp_Route<Concrete_Vrp_Route, Concrete_Vrp_Visit, Concrete_Vrp_Element> { }
    
    public class Concrete_Vrp_Solution : Generic_Vrp_Solution<Concrete_Vrp_Solution, Concrete_Vrp_Route, Concrete_Vrp_Visit, Concrete_Vrp_Element> { }
