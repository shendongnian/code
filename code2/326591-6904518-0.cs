    private IEnumerable<string> ReadLogLines(string logPath) {
        using(StreamReader reader = File.OpenText(logPath)) {
            string line = "";
            while((line = reader.ReadLine()) != null) {
                yield return line;
            }
        }
    }
