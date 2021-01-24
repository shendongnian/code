    namespace WebApplication22.Models
    {
        public class Model
        {
            public int Id { get; set; }
            public int MarkaId { get; set; }
 
            [ForeignKey(nameof(MarkaId))]
            public virtual Marka Marka { get; set; }
        }
    }
