    public class MasterCache<T, TDto>
    {
        private static ApplicationDbContext _context;
        private static List<TDto> _dtoGroups;
        public static List<TDto> Process(T data, bool ForceRefresh = false)
        {
            if (ForceRefresh || _dtoGroups == null)
            {
                _context = new ApplicationDbContext();
                _dtoGroups = Mapper<T, TDto>.Map(data);
            }
            return _dtoGroups;
        }
    }
