    //Reading...
    List<string> originalWords = new List<string>();
    using (var reader = new StreamReader(...)) {
        while (!reader.EndOfLine()) {
            string line = reader.ReadLine();
            var splitted = line.Split(new string[] {" "}, StringSplitOptions.None);
            foreach (var word in splitted) {
                if (!originalWords.Contains(word)) {
                    originalWords.Add(word);
                }
            }
        }
    }
    
    //Filtering...
    List<string> filtered = new List<string>();
    string vowels = "aeiou";
    foreach (var word in originalWords) {
        foreach (var vowel in vowels) {
            if (word.Contains(vowel))
                filtered.Add(vowel);
                break;
        }
    }
    //Writing...
    using (var writer = new StreamWriter(...)) {
        foreach (var word in filtered) {
            writer.WriteLine(word);
        }
    }
