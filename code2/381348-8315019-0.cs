    var text =
        "Here is some text. It has some sentences. There are a few sentences.";
    var word = "SOME";
    public List<String> GetSentences(String text, String word) {
        var sentences =
            text.Split(new[] { ". " }, StringSplitOptions.RemoveEmptyEntries);
    
        var matches = from sentence in sentences
                      where sentence.ToLower().Contains(word.ToLower())
                      select sentence;
        return matches.ToList();
    }
