    public static class CharacterGenerator
    {
         static List<Character> characterList = new List<Character>();
    
         public static Character CreateCharacter()
         {
              var character = ScriptableObject.CreateInstance<YourSo>();
              characterList.Add(character);
              return character;
         }
    }
