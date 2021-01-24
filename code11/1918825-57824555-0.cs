    public Patient()
            {
                Programs = new HashSet<Program>();
            }
            public virtual ICollection<PatientForm> Forms { get; set; }
