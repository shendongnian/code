    public class MySingleTon
      {
        static MySingleTon()
        {
          if (Instance == null)
          {
            Instance = new MySingleTon();
          }
        }
    
        private MySingleTon(){}
    
        public static MySingleTon Instance { get; private set; }
        public IMyRepository MyRepository{ get; set ;}
        
      }
