    public class InsertModel
    {
        [Display(...)]
        public virtual string ID { get; set; }
        ...Other properties
    }
    public class UpdateModel : InsertModel
    {
        [Required]
        public override string ID
        {
            get { return base.ID; }
            set { base.ID = value; }
        }
    }
