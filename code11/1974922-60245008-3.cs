           public List<Object>(String name){
               ArrayList result = new ArrayList();
               INetFwMgr firewallManager = 
  
  
  
  
  
  
                               (INetFwMgr)Activator.CreateInstance 
                               (Type.GetTypeFromProgID("HNetCfg.FwMgr"));
                               foreach (INetFwAuthorizedApplication app in 
                                firewallManager.LocalPolicy             
                               .CurrentProfile.AuthorizedApplications)
                             {
                              if(app.Name == _name){
                                 app.Name = name;
                                Console.WriteLine(app.Name);
                                   }
                                       }
                                 return result;
                                    }
