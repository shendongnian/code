    public T GetData<T>(string name) where T : Data
    {
        if (_cache.ContainsKey(name))
            return (T)_cache[name];
    
        using (var db = new LiteDatabase(_dbPath))
        {
            if (typeof(T) == typeof( ChartData)) //<======CORRECTION HERE
            {
                var collection = db.GetCollection<ChartData>("Data");
                var chunksColl = db.GetCollection<ValuesChunk>(nameof(ValuesChunk));
    
                var data = collection.Include(d => d.Series).FindOne(Query.EQ(nameof(ChartData.Name), name));
                foreach (var series in data.Series)
                {
                    for (int index = 0; index < series.Chunks.Count; index++)
                    {
                        var chunk = chunksColl.FindById(series.Chunks[index].ChunkId);
                        series.ChangeChunk(index, chunk);
                    }
                }
    
                _cache.Add(name, data);
                return data as Data;//<======CORRECTION HERE
            }
            else
            {
                var collection = db.GetCollection<T>();
                return collection.FindOne(Query.EQ(nameof(ChartData.Name), name));
            }
        }
    }
