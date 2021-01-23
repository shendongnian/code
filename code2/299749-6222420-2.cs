    public class Vet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    
        public Vet()
        {
            // default constructor
        }
     
        public Vet( IDataRecord record )
        {
            ID = (int) record["vetid"];
            Name = (string) record["vetname"];
            SurName = (string) record["vetsurname"];
        }
    
        public override string ToString()
        {
            return Name + " " + SurName;
        }
    }
