    public class Settings2 
    {
       public Extras OtherSettings;
       public string SomethingAtThisLevel;
    
    
       public void SomeMethod()
       {
          if( OtherSettings.itemTitle == "TESTING" )
             SomethingAtThisLevel = "ok";
       }
    }
