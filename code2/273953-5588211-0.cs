        public interface IPagination<T>
        {
            int PageSize { get; set; }
            int TotalPages { get; }
            IQueryable<T> GetPage(int page);
        }
