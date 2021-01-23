    public class KeyDate
    {
    ...
        public virtual ICollection<Association> Associations { get; set; }
        public KeyDate()
        {
           Associations = new List<Association>()
        }
    }
