    public class Schoolclass
    {
        public Schoolclass()
        {
            Pupils = new List<Pupil>();
        }            
    
        public int SchoolclassId { get; set; }
        public string SchoolclassCode { get; set; }
        public List<Pupil> Pupils { get; private set; }
    
    } 
