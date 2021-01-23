    public static void Main() {
        var lines = new[] { "umair,i,umair", "sajid,mark,i,k,i" };
        foreach (var line in lines) {
            var hashtable = new Hashtable();
            var records = line.Split(',');
            foreach (var record in records) {
                if (hashtable[record] == null)
                    hashtable[record] = 0;
                hashtable[record] = (Int32)hashtable[record] + 1;
            }
            var str = "";
            foreach (DictionaryEntry entry in hashtable) {
                var count = (Int32)hashtable[entry.Key];
                for (var i = 0; i < count; i++) {
                    str += entry.Key;
                    if (i < count - 1)
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
