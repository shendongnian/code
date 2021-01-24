 c#
    static void Main()
    {
        using (var conn = ConnectionMultiplexer.Connect("127.0.0.1:6379"))
        {
            var db = conn.GetDatabase();
            var watch = Stopwatch.StartNew();
            foreach(var batch in InventData(20000000).Batchify(5000))
            {
                db.StringSet(batch);
            }
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
or if I use `Parallel`, i.e.
 c#
            var watch = Stopwatch.StartNew();
            Parallel.ForEach(InventData(20000000).Batchify(5000),
                batch => db.StringSet(batch));
            watch.Stop();
it takes 16 seconds.
with 
 c#
    static IEnumerable<KeyValuePair<RedisKey, RedisValue>> InventData(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        string dictionary = "abcdefghijklmnopqrstuvwxyz _@:0123456789";
        int dLen = dictionary.Length;
        var rand = new Random(12345);
        const int KEY_LEN = 10, MAX_VAL_LEN = 50;
        char[] keyData = new char[KEY_LEN];
        char[] valueData = new char[MAX_VAL_LEN];
        while (count-- != 0)
        {
            for (int i = 0; i < keyData.Length; i++)
                keyData[i] = dictionary[rand.Next(dLen)];
            var len = rand.Next(10, MAX_VAL_LEN);
            for(int i = 0; i < len; i++)
                valueData[i] = dictionary[rand.Next(dLen)];
            yield return new KeyValuePair<RedisKey, SomeType>(
                new string(keyData), new string(valueData, 0, len));
        }
    }
    static IEnumerable<T[]> Batchify<T>(this IEnumerable<T> source, int batchSize)
    {
        var batch = new List<T>(batchSize);
        foreach(var item in source)
        {
            batch.Add(item);
            if (batch.Count == batchSize)
            {
                var arr = batch.ToArray();
                batch.Clear();
                yield return arr;
            }
        }
        if (batch.Count != 0) yield return batch.ToArray(); // trailers
    }
