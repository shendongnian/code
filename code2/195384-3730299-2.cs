    struct Point  
    {    
        static int x = 25;    
        static int y = 50;
        public void SetXY(int i, int j)    
        {        
            x = i;        
            y = j;    
        }     
    
        public static void ShowSum()            
        {        
            int sum = x + y;        
            Console.WriteLine("The sum is {0}",sum);    
        }
    }
