    public static void Main() {
        var lines = new[] { "umair,i,umair", "sajid,mark,i,k,i" };
        foreach (var line in lines) {
            var dictionary = new Dictionary<String, Int32>();
            var records = line.Split(',');
            foreach (var record in records) {
                if (!dictionary.ContainsKey(record))
                    dictionary.Add(record, 1);
                else
                    dictionary[record]++;
            }
            var str = "";
            foreach (var entry in dictionary) {
                for (var i = 0; i < entry.Value; i++) {
                    str += entry.Key;
                    if (i < entry.Value - 1)
                        str += ",";
                }
                str += ",";
            }
            // Remove last comma.
            str = str.TrimEnd(',');
            Console.WriteLine(str);
        }
        Console.ReadLine();
    }
