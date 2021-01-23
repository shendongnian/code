    public class MySingleTon
    {
        private MySingleTon()
        {
           // You constructor logic, maybe create a reference 
           // to your repository if you need it
        }
        private static MySingleTon _instance;
        public static MySingleTon Instance { 
           get
           {
              if(_instance == null)
                 _instance = new MySingleTon();
              return _instance;
           }
        }
        public string prop1 { get; set; }
        public string prop2 { get; set; }
    }
