    var dictionary = new Dictionary<string, string>();
    var lines = File.ReadLines("testScores.txt");
    var e = lines.GetEnumerator();
    while(e.MoveNext()) {
        if(e.Current.StartsWith("#Test")) {
            string test = e.Current;
            if(e.MoveNext()) {
                dictionary.Add(test, e.Current);
            }
            else {
                throw new Exception("File not in expected format.");
            }
        }
    }  
