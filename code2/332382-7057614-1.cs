    public IsCommitted { 
       get { return _isCommitted; } 
       set {  
         _isCommitted = value; 
         if (CommittedChanged != null) CommittedChanged(_isCommitted);
       }
    }
