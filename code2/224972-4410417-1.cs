    class Person
    {
        public Person()
        {
            this.EmploymentStatus = EmploymentStatus.Unemployed;
        }
        public void Hire(Company employer, string occupation)
        {
            this.Occupation = occupation;
            this.Employer = employer;
            this.EmploymentStatus = EmploymentStatus.Employed;
        }
        public void Fire()
        {
            this.Occupation = null;
            this.Employer = null;
            this.EmploymentStatus = EmploymentStatus.Unemployed;
        }
        public EmploymentStatus EmploymentStatus { get; private set; }
        public string Occupation { get; private set; }
        public Company Employer { get; private set; }
    }
