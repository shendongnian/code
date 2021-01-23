    public class Revex{
      public IEnumerable<char> AllCharacters;
      public Revex(){
         AllCharacters = Enumerable.Range(0, 256).Select(Convert.ToChar).Where(c => !char.IsControl(c)).ToArray()
      }
      
      public Revex(IEnumerable<char> allCharacters){
        AllCharacters = allCharacters;
      }
    }
