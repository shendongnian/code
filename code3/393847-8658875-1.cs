    bool EverythingIsFine = true;
    try{
         //Your code
    }
    catch(Exception){
        if(Condition){
            EverythingIsFine = false;
            ShowRelatedAlerts();
        }
    }
    if(!EverythingIsFine){
        //DoMoreStuff
    }
