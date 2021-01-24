    public class IndexObjectViewModel : EntityWithNameAndId
    {
        public virtual Site Site { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Planning> Plannings { get; set; }
        //To store User instead of its Id
        public virtual User Pilote { get; set; }
    }
