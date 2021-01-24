    public class TransitTime : List<double>{
    
        public TransitTime() : base(){
        }
        
        public static TransitTime operator - (TransitTime c1, double c2)  
        {  
            // Here we implement subtraction as subtracting c2 from every member of c1
            TransitTime endTimes = new TransitTime();
            for (int i = 0; i < c1.Count; i++){
                endTimes.Add(c1[i] - c2);
            }
            return endTimes;
        }
        
        public static TransitTime operator / (TransitTime c1, TransitTime c2)  
        {  
            // Here we implement division as dividing every member of c1 by every member of c2
            TransitTime endTimes = new TransitTime();
            for (int i = 0; i < c1.Count; i++){
                endTimes.Add(c1[i] / c2[i]);
            }
            return endTimes;
        }  
    }
