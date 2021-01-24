    namespace admin.models
    {
        public class BaseClass
        {
            [Required]
            public string id { get; set; }
            [Required]
            public virtual string name { get; set; }
        }
    
        public class NewClass : BaseClass
        {
            public override string name { get; set; }
        }
    }
