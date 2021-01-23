    public class User
        {
            public virtual int Id { get; set; }
            public virtual IList<Names> Names { get; set; }
            public virtual IList<Addresses> Addresses { get; set; }
        }
