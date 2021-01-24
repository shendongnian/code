    //make a strongly typed class to represent your dictionary entry
    public class Definition{
      public string Phonetic {get; set;}
      public string Grammar {get; set;}
      public string Meaning {get; set;}
      public string Sentence {get; set;}
      public override ToString(){
        return $"{Phonetic}\r\n{Grammar}\r\n{Meaning}\r\n{Sentence}";
      }
    }
    //in your windows form, something like this gets your db entry, converts it to an instance of the Definiton class, disposes the connection etc:
    using (var db = DapperConnectionFactory())
    {
      var wordDef = db.QueryFirstOrDefault<Definition>("SELECT phonetic,grammar,meaning,sentence FROM dictionaryTable WHERE word LIKE @word", _wahkiWordRtb.Trim());
      
      EnglishMeningRTB.Text = wordDef?.ToString() ?? "Word not found";
    }
