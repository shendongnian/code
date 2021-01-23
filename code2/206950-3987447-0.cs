     public void GetAllAppDomains()
                 {
          
                     AppDomain one = AppDomain.CreateDomain("One");
                     AppDomain two = AppDomain.CreateDomain("Two"); 
                    // Creates 2 app domains           
          
                     List<AppDomain> appDomains = new List<AppDomain>();
          
                     IntPtr enumHandle = IntPtr.Zero;
          
                     CorRuntimeHostClass host = new CorRuntimeHostClass();          
          
                     try
                     {
          
                         host.EnumDomains(out enumHandle);
          
                         object domain = null;
          
                         AppDomain tempDomain;
          
                         while (true)
                         {
          
                             host.NextDomain(enumHandle, out domain);
          
                             if (domain == null)
                             {
                                 break;
                             }
          
                             tempDomain = domain as AppDomain;
          
                             appDomains.Add(tempDomain);
          
                         }               
          
                     }
          
                     catch (Exception ex)
                     {
                         Console.WriteLine(ex.ToString());          
                     }
          
                     finally
                     {
                         host.CloseEnum(enumHandle);
                         int rel= Marshal.ReleaseComObject(host);
                     }
          
                     Assembly[] assemblies;
                     foreach (AppDomain app in appDomains)
                     {
                         Console.WriteLine(app.FriendlyName);
          
                         assemblies = app.GetAssemblies();
          
                         Console.WriteLine("-----------------------Assemblies------------------");
                         foreach (Assembly assem in assemblies)
                         {
                             Console.WriteLine(assem.FullName);
                         }
                         Console.WriteLine("---------------------------------------------------");
                     }
          
                 }
