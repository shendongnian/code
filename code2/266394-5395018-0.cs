    public class ArtworkDataLabel : ArtworkLabel
    {
        public string Data { get; set; }
        public override int ID { get; set; }
    
        public ArtworkDataLabel()
        {
            this.ID = 5;
        }
    }    
    
    public class ArtworkLabel
    {
        public virtual  int ID { get; set; }
    }
