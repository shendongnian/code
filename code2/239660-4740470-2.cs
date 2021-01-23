    public class Schoolclass
    {
        public Schoolclass()
        {
            Pupils = new BindingList<Pupil>(); 
                // binding list descends from Collection<T> 
                
        }            
        public int SchoolclassId { get; set; }
        public string SchoolclassCode { get; set; }
        public Collection<Pupil> Pupils { get; private set; }
    }
 
