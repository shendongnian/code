     public class Page
    {
        public Page(int number, int size)
        {
            this.Number = number;
            this.Size = size;
        }
        public int Number { get; }
        public int Size { get; }
        public static IEnumerable<Page> 
            Paginate(DataSet data, int pageSize)
        {
            // how to divide data per page?
            // there's no indication in your logic
            // for this
            int rows = data.Tables[0].Rows.Count;
            int total = (int)Math.Ceiling(
                (decimal)rows / (decimal)pageSize);
            return Enumerable
                .Range(0, total)
                .Select(index => new Page(index, pageSize));
        }
    }
    public class Pagination
    {
        int currentIndex = 0;
        public Pagination(IEnumerable<Page> pages)
        {
            this.Pages = pages;
        }
        public IEnumerable<Page> Pages { get; }
        public bool HasNext
            => this.Pages.Count() > currentIndex;
        public bool HasPrevious
           => 0 < currentIndex;
        public Page Next()
        {
            if (!HasNext)
                throw new InvalidProgramException();
            currentIndex++;
            return this.Pages.ToList()[currentIndex];
        }
        public Page Previous()
        {
            if (!HasPrevious)
                throw new InvalidProgramException();
            currentIndex--;
            return this.Pages.ToList()[currentIndex];
        }
    }
