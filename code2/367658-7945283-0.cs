    interface IExamplePropertyService
    {
      int ExampleProperty { get; set; }
    }
    public class AGameInXNA : Microsoft.Xna.Framework.Game, IExamplePropertyService
    { 
         int ExampleGameProperty { get; set; }
         void Initialize()
         {
             // Do other initialization
             Services.Add( typeof(IExamplePropertyService), this );
         }
    } 
    public class ReferenceToAGameInXNA    
    {    
         IExamplePropertyService propertyService;    
         public void GetGameInstance(Game game)    
         {    
              propertyService = (IExamplePropertyService)game.GetService( typeof(IExamplePropertyService) );    
         }    
        
         public void SetExampleGameProperty()    
         {    
              propertyService.ExampleGameProperty = 21;  
         }    
    }    
