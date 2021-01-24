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
                var entity = transform(line); // <-- or line.Split("\t")
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
Import(filename, line => {
   var data = line.Split("\t");
   / * do whatever you need to transform the data */
   return new Account(data);
})
// or
Import(filename, splits => {
   / * do whatever you need to transform the data */
   return new Whatever(splits);
})
