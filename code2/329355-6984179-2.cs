        interface ILogicBAware
        {
          void DoB();
        }
        
        interface ILogicCAware
        {
          void DoC();
        }
    
        interface IAllMethods : ILogicBAware, ILogicCAware
        {
           void DoAll();
        }
