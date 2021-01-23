    public interface IDbColumn
        {
            int domainID { get; set; }
        }
        public static IEnumerable<T> GetDataByDomain<T>(
            IQueryable<T> src) where T:IDbColumn
        {
            string url = HttpContext.Current.Request.Url.Host;
            int i = url == "localhost" ? 1 : 2;
            return src.Where(x => x.domainID == i|| x.domainID == 3);
        }
