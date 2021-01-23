    using(StreamReader sr = new StreamReader("my file")) {
        Dictionary<string, int> items = new Dictionary<string, int>();
    
        while(sr.BaseStream.Position < sr.BaseStream.Length) {
            string s = sr.ReadLine();
            if(items.ContainsKey(s)) {
                items[s]++;
            } else {
                items.Add(s, 1);
            }
        }
    
        // You now have a dictionary of unique strings and their counts - you can sort it however you need.
    }
