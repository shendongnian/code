    public abstract class GameBase : Microsoft.Xna.Framework.Game
    {
         public int ExampleGameProperty { get; set; }
    }
    public class AGameInXNA : GameBase
    {
        // code specific to AGameInXNA 
    }
    
    public class ReferenceToAGameInXNA
    {
         public GameBase GameInstance { get; set; }
    
         public void SetExampleGameProperty()
         {
              GameInstance.ExampleGameProperty = 21;
         }
    }
