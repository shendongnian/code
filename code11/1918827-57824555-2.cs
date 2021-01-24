    public TxCyclePhase()
            {
                this.FormPats = new HashSet<PatientForm>();
            }
    
            public int Id { get; set; }
            public virtual ICollection<PatientForm> FormPats { get; set; }
