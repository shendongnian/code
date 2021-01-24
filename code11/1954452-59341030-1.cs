    public static void Writetermdoc(Dictionary<TermDocs, float> dictionary, string file)
    {
       using (StreamWriter writer = new StreamWriter(file))
       {
           // Write pairs.
           foreach (var pair in dictionary)
           {
              writer.WriteLine("{0}|{1}|{2}", pair.Key.documentid, pair.Key.term, pair.Value);
           }
        }
    }
