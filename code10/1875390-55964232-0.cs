        `public partial class PersonOrganisation
            {
                private Person person;
                private Organisation organisation;
                private ILazyLoader LazyLoader { get; set; }
                private PersonOrganisation(ILazyLoader lazyLoader)
                {
                    LazyLoader = lazyLoader;
                }
                public PersonOrganisation()
                {
                }
        
                public Guid? PersonId { get; set; }
                public Guid? OrganisationId { get; set; }
        
                public virtual Organisation Organisation {
                    get => LazyLoader.Load(this, ref organisation);
                    set => organisation = value;
                }
        
                public virtual Person Person {
                    get => LazyLoader.Load(this, ref person);
                    set => person = value;
                }
            }`
