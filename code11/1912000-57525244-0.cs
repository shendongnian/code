    public class MultipleModels
    {
        public Doctors Doctors {get;set;}
        public Patients Patients {get;set;}
        public IndexModel IndexModel {get;set;}
        public MultipleModels()
        {
           this.IndexModel = new IndexModel();
           this.Doctors = new Doctors();
           this.Patients = new Patients();
        } 
    }
