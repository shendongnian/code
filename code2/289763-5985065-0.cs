    public class CatFilter
    {
        public List<string> Names = new List<string>();
        public List<string> Colors = new List<string>();
        public DateTime? BirthDateStartRange = null;
        public DateTime? BirthDateEndRange = null;
    }
    public List<Cat> GetFilteredCats(CatFilter filter)
    {
        List<Cat> result = new List<Cat>();
        var query = cats
            .Where(a => !filter.Names.Any() || filter.Names.Contains(a.Name))
            .Where(a => !filter.Colors.Any() || filter.Colors.Contains(a.Color))
            .Where(a => filter.BirthDateStartRange == null || a.DateOfBirth >= filter.BirthDateStartRange)
            .Where(a => filter.BirthDateEndRange == null || a.DateOfBirth <= filter.BirthDateEndRange);
        result.AddRange(query);
        return result;
    }
