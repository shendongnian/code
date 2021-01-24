    public class DtSkmService
    {
        private DtSkmContext _context;
        public DtSkmService(DtSkmContext context)
        {
            _context = context;
        }
        public void Add(int ndrawing1, Int16 ndrawing2)
        {
            var dtSkm = new DtSkmDto { Ndrawing1 = ndrawing1, Ndrawing2 = ndrawing2 };
            _context.DtSkm.Add(dtSkm);
            _context.SaveChanges();
        }
        public IEnumerable<DtSkmDto> Find(int first, Int16 second)
        {
            return _context.DtSkm
                .Where(b => b.Ndrawing1.Equals(first) && b.Ndrawing2.Equals(second))
                .OrderBy(b => b.Ndrawing1)
                .ToList();
        }
    }
