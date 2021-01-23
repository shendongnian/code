        [Required] <-- even if the FK is nullable, OrgUnit will be Required
        [StringLength(10)]
        [ForeignKey("OrgUnit"), Column(Order = 1)]
        public string OrgCode
        {
            get;
            set;
        }
       
        ... other FK, Column order 0   
        public virtual OrgUnit OrgUnit
        {
            get;
            set;
        }
