    bool ServiceWasDown = false;
    DateTime ServiceDownTime = DateTime.Now;
    DateTime LastEmailTime = DateTime.Now;
    
    void OnTimerElapsed()
    {
       if(IsServiceDown())
          ServiceDown();
       else
          ServiceUp();
    }
    
    void ServiceDown()
    {
       if(ServiceWasDown)//already know about service
       {
          //if LastEmailTime more than 10 minutes ago send another email and update LastEmailTime
       }
       else//service just went down
       {
          //send new email
          LastEmailTime = DateTime.Now;
          ServiceWasDown = true;
          ServiceDownTime = DateTime.Now;
       }   
    }
    
    void ServiceUp()
    {
       ServiceWasDown = false;   
    }
