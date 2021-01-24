    public class ClassNameForTheJson {
      public CharacterKey characterKey;
    }
    
    // Somewhere...
    public class CharacterKey {
      pubic string charName;
    
      public string charQuote;
    
      public string charImageURL;
    }
    
    // Somewhere again...
    ClassNameForTheJson yourDeserializedData = JsonConvert.DeserializeObject<ClassNameForTheJson>(yourJsonFileString);
    var characterQuoteFromJSON = yourDeserializedData.characterKey.charQuote;
