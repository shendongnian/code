    public class Generic_Tsp_Element<E> : Generic_Element<E>
    where E : Generic_Tsp_Element<E>
    {
    }
    
    /// <summary>Visit to a Generic_Element</summary>
    public class Generic_Tsp_Visit<V, E> : Generic_Visit<V, E>
        where V : Generic_Tsp_Visit<V, E>
        where E : Generic_Tsp_Element<E>
    {
        public Double Time { get; set; }
    }
    
    /// <summary>Collection of Visits</summary>
    public class Generic_Tsp_Route<R, V, E> : Generic_Route<R, V, E>
        where R : Generic_Tsp_Route<R, V, E>
        where V : Generic_Tsp_Visit<V, E>
        where E : Generic_Tsp_Element<E>
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
    public class Generic_Tsp_Solution<S, R, V, E> : Generic_Solution<S, R, V, E>
        where S : Generic_Tsp_Solution<S, R, V, E>
        where R : Generic_Tsp_Route<R, V, E>
        where V : Generic_Tsp_Visit<V, E>
        where E : Generic_Tsp_Element<E>
    {
        public Double Time
        {
            get
            {
                return this.Routes.Select(r => r.Time).Sum();
            }
        }
    }
    
    public class Concrete_Tsp_Element : Generic_Tsp_Element<Concrete_Tsp_Element> { }
    
    public class Concrete_Tsp_Visit : Generic_Tsp_Visit<Concrete_Tsp_Visit, Concrete_Tsp_Element> { }
    
    public class Concrete_Tsp_Route : Generic_Tsp_Route<Concrete_Tsp_Route, Concrete_Tsp_Visit, Concrete_Tsp_Element> { }
    
    public class Concrete_Tsp_Solution : Generic_Tsp_Solution<Concrete_Tsp_Solution, Concrete_Tsp_Route, Concrete_Tsp_Visit, Concrete_Tsp_Element> { }
