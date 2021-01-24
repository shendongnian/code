     public class Entity
     {
        public String Id { get; set; }
        public String code
        {
            get
            {
                return Id; 
            }
            set
            {
                Id = value;
                IdDuplicate = value;
            }
        }
        public String IdDuplicate { get; set; }
    }
