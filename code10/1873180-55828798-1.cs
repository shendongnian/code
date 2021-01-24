    using(StreamWriter stream = new StreamWriter("result.txt"))
    {
        XDocument doc = XDocument.Load(@"path.to.x.document");
        var sentences = doc.Descendants("sentence");
        foreach (var sentence in sentences)
        {
            var line = string.Empty;
			var words = sentence.Elements("word");
			var lastWord = words.LastOrDefault();
            foreach (var word in words.Take(words.Count()-1))
            {
                line = string.join(
                   " ",
                   line,
                   word.Attribute("lemma").Value,
                   word.Attribute("postag").Value
                );
            }
            line = string.Join(string.Empty, line, lastWord.Attribute("lemma").Value);
            stream.WriteLine(line);
        }
    }
    
