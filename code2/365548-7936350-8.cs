    public partial class ContainsTestEntities
    {
        public IEnumerable<Main> GetMainItems(IEnumerable<int> ids, int chunkSize = 100)
        {
            foreach (var chunk in ids.Chunk(chunkSize))
            {
                var q = this.MainItems.Where(a => chunk.Contains(a.Id));
                foreach (var item in q)
                {
                    yield return item;
                }
            }
        }
    }
