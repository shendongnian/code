    // Process file 1
    if(!ProcessFile()){
     
       // Processfile 2
       if(!ProcessFile()){
        
         //etc..
       }
    
    }
    private bool ProcessFile(){
        bool error = false;
        try{
           // do work   
        }
        catch{
           error = true;    
        }
        return error;
    }
