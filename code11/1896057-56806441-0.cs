    public class CaseWorkNote : FullAuditedEntity
        {
            [ForeignKey("CaseId")]
            [Required]
            public virtual Case Case { get; private set; }    
            public virtual Guid CaseId { get; private set; }  /* Added */
    
            [Required]
            public virtual string Text { get; set; }   
             
            private CaseWorkNote() : base() { }
    
            public static CaseWorkNote Create(Case kase, string text)
            {
                return new CaseWorkNote()
                {
                    Case = kase,
                    Text = text
                };
            }
        }
