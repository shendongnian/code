    namespace ConsoleApplication2 {
        class Program {
            static void Main(string[] args) {
                string line;
                //initialize Dictionary
    
                var keyMatch = new Dictionary<string, string>();
                //opening the file
                using (TextReader re = File.OpenText("Sample.txt")) {
                    //loop through lines
                    while ((line = re.ReadLine()) != null) {
                        keyMatch.Add(line.Substring(0, line.IndexOf("-")), line.Substring(line.IndexOf("-") + 1));
                    }
                }
    
                var test = keyMatch["Info5"];
            }
        }
    }
