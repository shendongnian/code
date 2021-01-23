    public class Pagination<T> {
        public IQueryable<T> Items { get; set; }
        public int PageSize { get; set; }
        public int TotalPages {
            get {
                if (this.Items.Count() % this.PageSize == 0)
                    return this.Items.Count() / this.PageSize;
                else
                    return (this.Items.Count() / this.PageSize) + 1;
            }
        }
        public Pagination(IQueryable<T> items, int pageSize) {
            this.PageSize = pageSize;
            this.Items = items;
        }
        public IQueryable<T> GetPage(int pageNumber) {
            pageNumber = pageNumber - 1;
            return this.Items.Skip(this.PageSize * pageNumber).Take(this.PageSize);
        }
    }
