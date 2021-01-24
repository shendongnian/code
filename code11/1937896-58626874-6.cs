      public  class MyObjets 
    {
        public string Designation { get; set; }
        public string Description { get; set; }
        public float Prix { get; set; }
        public int nbr_objet { get; set; }
        public MyObjets(string Designation, string Description, float Prix, int nbr_objet)
        {
            this.Designation = Designation;
            this.Description = Description;
            this.Prix = Prix;
            this.nbr_objet = nbr_objet;
        }
       
    }
