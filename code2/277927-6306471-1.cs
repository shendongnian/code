    public class Contract: Entity <short>
    {
        public virtual COrganization COrganization
        {
            get { return cOrganization; }
            protected internal set
            {
                if (cOrganization != null && value != cOrganization) // != calls ==, which calls Equals, which calls GetUnproxiedType()
                        throw new Exception("Changing organization is not allowed.");
                }
                cOrganization = value;
            }
        }
        private COrganization cOrganization;
    }
