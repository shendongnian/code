    class PageList : System.ComponentModel.IListSource
    {
        private const int itempagesize = 250;
        private long totalitems;
        public PageList(string tablename, long totalrecords)
        {
            this.TableName = tablename;
            totalitems = totalrecords;
        }
        public bool ContainsListCollection { get; protected set; }
        public System.Collections.IList GetList()
        {
            List<ItemPage> pages = new List<ItemPage>();
            int totalPages = (int)Math.Ceiling((double)totalitems / (double)itempagesize);
            pages.AddRange(Enumerable.Range(0, totalPages).Select(pageidx => new ItemPage(itempagesize, pageidx * itempagesize)));
            return pages;
        }
        public string TableName { get; protected set; }
        public class ItemPage
        {
            public ItemPage(int limit, int offset)
            {
                this.Limit = limit;
                this.Offset = offset;
            }
            public readonly int Limit;
            public readonly int Offset;
        }
    }
