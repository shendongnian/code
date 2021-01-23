    class Person
    {
        public PersonState Status {get;set;}
        public bool IsArchived
        {
            get { return (this.Status & PersonState.Archived) != 0; }
        }
        public bool IsDeleted
        {
            get { return (this.Status & PersonState.Deleted) != 0; }
        }
    }
