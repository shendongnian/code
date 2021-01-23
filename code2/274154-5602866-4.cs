    namespace StructureMapTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ObjectFactory.Initialize(x => 
                               { 
                                  x.PullConfigurationFromAppConfig = true; 
                               });
    
                    var translator = ObjectFactory.GetInstance<ITranslator>();
    
                    Console.WriteLine(translator == null);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
    
                Console.ReadLine();
            }
        }
    }
