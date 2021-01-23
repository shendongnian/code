    namespace Test
    {
        class Program
        {
            //Change this value to show how the Actions bail when you DoesWebsiteNotExists 
            //returns false
            static bool isvalid = true;
            static void Main(string[] args)
            {
                List<System.Func<bool>> MainActions = new List<System.Func<bool>>();
    
                List<System.Func<bool>> CompositeActions = new List<System.Func<bool>>();
    
                MainActions.Add(() => NonCompositeAction());
                
               //Probably want a builder here.
                CompositeActions.Add(() => DoesWebsiteNotExists());
                CompositeActions.Add(() => CreatePhyiscalDir());
                CompositeActions.Add(() => CreateVirDirectories());
                CompositeActions.Add(() => CreateWebsite());
    
                MainActions.Add(() => ExcuteCompositeActions(CompositeActions));
    
                foreach (Func<bool> action in MainActions)
                    action.Invoke();
                  
     
    
            }
    
    
            static bool ExcuteCompositeActions(List<System.Func<bool>> Actions)
            {
    
              
    
                bool Success = true;
                foreach (Func<bool> action in Actions)
                {
                    if (!action.Invoke())
                    {
                        Success = false;
                        break;
                    }
    
                }
                return Success;
            }
    
            static bool NonCompositeAction()
            {
                Console.WriteLine("NonCompositeAction");
                return true;
            }
    
            static bool DoesWebsiteNotExists()
            {
                Console.WriteLine("DoesWebsiteExists");
                return isvalid;
            }
             static bool CreatePhyiscalDir()
            {
                Console.WriteLine("CreatePhyiscalDir");
                return true;
            }
            static bool CreateWebsite()
            {
                Console.WriteLine("CreateWebsite");
                return true;
            }
            static bool CreateVirDirectories()
            {
                Console.WriteLine("CreateVirDirectories");
                return true;
            }
    
             
    
               
                
                    
            }
    
        }
