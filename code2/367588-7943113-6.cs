    [Flags]
    public enum PersonState
    {
        None = 0,
        Archived = 1,
        Deleted = 2,
        Both = Archived | Deleted
    }
    class Person
    {
        private PersonState status;
        public PersonState Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public bool IsArchived
        {
            get
            {
                return (this.status & PersonState.Archived) != 0;
            }
            set
            {
                if (value)
                    this.status |= PersonState.Archived;
                else
                    this.status &= ~PersonState.Archived;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (this.status & PersonState.Deleted) != 0;
            }
            set
            {
                if (value)
                    this.status |= PersonState.Deleted;
                else
                    this.status &= ~PersonState.Deleted;
            }
        }
    }
