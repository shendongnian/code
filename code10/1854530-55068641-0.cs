    public class PagedItems<T>
    {
        private readonly int pageSize;
        public PagedItems()
        {
        }
        public PagedItems(int offset, int pageSize, int totalSize, IEnumerable<T> subset, Uri baseUri)
        {
            this.Offset = offset;
            this.pageSize = pageSize;
            this.TotalSize = totalSize;
            this.Data = subset;
            this.Links = new Dictionary<string, string>();
            if (ShouldDisplayPrevAndFirstLink(offset))
            {
                var linkValue = Math.Max(offset - pageSize, 0);
                var link = QueryHelpers.AddQueryString(baseUri.OriginalString, "skip", linkValue.ToString());
                this.Links.Add("prev", link);
            }
            if (ShouldDisplayNextAndLastLink(offset, totalSize, pageSize))
            {
                var linkValue = offset + pageSize;
                var link = QueryHelpers.AddQueryString(baseUri.OriginalString, "skip", linkValue.ToString());
                this.Links.Add("next", link);
            }
            if (ShouldDisplayPrevAndFirstLink(offset))
            {
                var link = QueryHelpers.AddQueryString(baseUri.OriginalString, "skip", "0");
                this.Links.Add("first", link);
            }
            if (ShouldDisplayNextAndLastLink(offset, totalSize, pageSize))
            {
                var linkValue = totalSize - pageSize;
                
                var link = QueryHelpers.AddQueryString(baseUri.OriginalString, "skip", linkValue.ToString());
                this.Links.Add("last", link);
            }
        }
        private static bool ShouldDisplayNextAndLastLink(int offset, int totalSize, int pageSize) => offset < totalSize - pageSize;
        private static bool ShouldDisplayPrevAndFirstLink(int offset) => offset > 0;
        public int Offset { get; }
        public int Size => this.Data.Count();
        public int TotalSize { get; }
        public IEnumerable<T> Data { get; }
        public Dictionary<string, string> Links { get; }
    }
