    string inp = @"~T!@#e$мудак%š^t<>is69&.,;((טעראָר))_+}{{男子}[죽은]ที่เดิน:?/Ök\|`'+*-¤=";
    Regex reg = new Regex("[^A-Za-zšžõäöüŠŽÕÄÖÜ]");
    
    foreach (string s in reg.Split(inp))
    {
          if (String.IsNullOrEmpty(s))
               continue;
               
          Console.Write(s + " ");
    }
