    public class Ninja{
        Ninja(){
        }
    
        public void ThrowShirikin(int numberOfShirikins){
                if(numberOfShirikins <= 0){
                    throw new System.ArgumentException("Invalid number of shirikins");
                }
            //Throw shirikin
        }
    }
