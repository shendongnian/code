        public class EntityDb1 : IDatedEntity
        {
            public DateTime AddedDate { get; set; }
    
            public DateTime MyDate => AddedDate;
        }
        public class EntityDb2 : IDatedEntity
        {
            public DateTime CreatedDate { get; set; }
    
            public DateTime MyDate => CreatedDate;
        }
    
        public interface IDatedEntity
        {
            DateTime MyDate{ get; }
        }
