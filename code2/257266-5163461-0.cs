    public class test {
        private Object[] _obj;
    
        protected void myMethodLocal() {
            Object[] obj = _obj;
    
            // Is there an appreciable differnce between
            for(int i = 0; i < obj.length; i++) { 
                // do stuff
            }
        }
          
       protected void myMethodMember() {
            // and this?
            for(int i = 0; i < this._obj.length; i++) { 
                // do stuff
            }
       }
    }
