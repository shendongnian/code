    abstract class Handler
     {
       protected Handler next;
       
       public Handler(Handler h){
          this.next = h;
       }
       public abstract bool Validate(Request request); 
       public abstract void Handle(Request request);
    }
    
    class CoreLogic: Handler
    {   
       public CoreLogic(Handler handle) : base(handle){
    
       }
       public override void Validate(Request request){
             return True
       }
       public override void Handle(Request request){
            if(this.Validate(request)){
                if(next!= null){
                  next.Handle(request);
               }
            }
    
       }
    }
    
    class ValidBalance: Handler
    {   
       public ValidBalance(Handler handle) : base(handle){
    
       }
       public override void Validate(Request request){
            return True
       }
       public override void Handle(Request request){
            if(this.Validate(request)){
                if(next!= null){
                  next.Handle(request);
               }
            }
            
        }
    }
    
    class MainApp
    {
       static void Main(){
           Handler h = new ValidateBalance( new CoreLogic(null));
           h.Handle(new Request());
    
       }
    }
