    public class Intervention
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public InterventionStates InterventionStateId { get; set; }
        public virtual InterventionState InterventionState { get; set; }
    }
    
    public class InterventionState
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Intervention> Interventions { get; set; }
    
    }
