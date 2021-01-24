        public static Temporizador clssMestTime = new Temporizador();  
        
        public static int[] TimeMeseta = { 1000, 2000, 3000, 4000, 5000 };
    
        public static void Main()
        {
    
            for (int i = 0; i < 5; i++)
            {            
                int newMesetaTime = TimeMeseta[i];         
                clssMestTime.defTime(newMesetaTime);            
            }
        }
    }
