    //assumed class for demonstration only
    public class Data
    {
        public string name { get; set; }
        public string desc { get; set; }
    }
    //extension method 
    public static class ListExtensions
    {
        public static string GetFirstProperty(this List<Data> list, Expression<Func<Data, string>> predicate)
        {
            var compiledSelector = predicate.Compile();
            return list.Select(x => string.IsNullOrWhiteSpace(compiledSelector(x)) ? "Not Available" : compiledSelector(x)).FirstOrDefault();
        }
    }
    var name = MainList.GetFirstProperty(x => x.name);
    var desc = MainList.GetFirstProperty(x => x.desc);
