    public class IDs{
    
        public string someID{ get; set; }
    
        public IDs(string someId){
    		this.someID = someId;
            log.info(this.someID);
               //use someID here
        }
    }
    
    pulic class otherClass{
    
    
         public otherMethod(string sym){
    				IDs id = new IDs(sym);
                }
          }
    
    public class anotherClass{
    
                    //access instance of otherClass in wrp and call otherMethod()
                   wrp.otherMethod("someStringSymbol")
             }
