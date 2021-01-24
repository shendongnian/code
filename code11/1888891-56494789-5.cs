private static async Task<int> Import<T>(string filename, Func<string, T> transform) where T : class
{
    var totalRecords = await GetLineCount(filename);
    var ctx = new AccountContext();
    var count = 0;
    var records = 0;
    using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    {
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var data = line.Split("\t");
                var entity = transform(data);
                await ctx.AddAsync(entity);
                if (count % 10000 == 1)
                {
                    records += result = await ctx.SaveChangesAsync();
                    if (result > 0)
                    {
                        ctx.Dispose();
                        ctx = new AccountContext();
                    }
                }
                count++;
            }
        }
    }
    await ctx.SaveChangesAsync();
    ctx.Dispose();
    return records;
}
// Usage
Import(filename, splits => new Account(splits)});
Import(filename, splits => new Whatever(splits)});
Import(filename, splits => new Whatever2(splits)});
Import(filename, splits => new Whatever3(splits)});
