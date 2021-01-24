    public class CharacterManager
    {
       private static CharacterManager singleton;
       private Skin currentSkin;
   
       public static CharacterManager Singleton
       {
          get
          {
             if (singleton == null)
             {
                singleton = new CharacterManager();
             }
         
             return singleton;
          }
       }
       public void SelectSkin(Skin skin)
       {
           currentSkin = skin;
       }
       
       public Skin GetCurrentSkin()
       {
           return currentSkin;
       }
    }
