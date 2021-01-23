    var collection = File.ReadLines(@"C:\found.txt")
        .ToDictionary(s => s.Split('\\')[3].Replace(".txt", ""));
    using (var writer = new StreamWriter(@"C:\Copy.txt")) {
        foreach (string found in foundlist) {
            string splitFound = found.Split('|');
            string matchFound = Path.GetFileNameWithoutExtension(found)
            
            string collectedLine;
            if (collection.TryGetValue(matchFound, collectedLine)) {
                end++;
                long finaldest = (start - end);
                Console.WriteLine(finaldest);
                writer.WriteLine("copy \"" + collectedLine + "\" \"C:\\OUT\\" 
                               + splitFound[1] + "\\" + spltifound[0] + ".txt\"");
            }
        }
    }
