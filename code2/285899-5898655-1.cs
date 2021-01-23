     public class Job
        {
            public virtual int ID { get; set; }
            public virtual string Name { get; set; }
            public virtual IList<Role> Roles { get; set; }
        }
