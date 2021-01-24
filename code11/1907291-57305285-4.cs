    public List<VocabularyData> LoadVocabulary() {
      try {
        return File
          .ReadLines(GetFileName())
          .Where(line => !string.IsNullOrWhiteSpace(line)) // to be on the safe side
          .Select(line => line.Split('|'))
          .Select(voc => new VocabularyData() {
             VocGerman    = voc[0],
             VocEnglish   = voc[1],
             CreationDate = DateTime.Parse(voc[2]), 
             AssignedDate = DateTime.Parse(voc[3]),
             SuccessQueue = voc[4],
             TimeQueue    = voc[5]
           })
          .ToList();
      }
      catch (IOException ex) {
        //TODO: do not throw general Exception but derived 
        throw new InvalidOperationException($"Error loading Vocabulary: {ex.Message}", ex);
      }
    }
 
