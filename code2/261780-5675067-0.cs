    public class mydbClass{ 
        private static mydbClass  _current = new    mydbClass(); 
        public static mydbClass Current{
            get{
                return _current;
            }
        } 
        private mydbClass(){} 
        public User getUserName(userid){
        //be sure to create a new connection each times
        }
    }
