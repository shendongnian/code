    public class defaultAble<T>{
        readonly T defaultValue;
    
        //constructor
        public defaultAble(T defaultValue){
            this.defaultValue = defaultValue;
            //First set the value
            RestoreDefault();
        }
    
        public RestoreDefault(){
            value = this.defaultValue;
        }
        
        public T value { get; set; }
    }
