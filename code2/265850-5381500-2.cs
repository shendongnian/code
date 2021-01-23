    public interface ISearch
    {
        IEnumerable<string> Search(string filter);
    }
    public interface IPhoneSearch : ISearch
    {
        new IEnumerable<string> Search(string filter);
    }
    public class Searchable : IPhoneSearch
    {
        public IEnumerable<string> Search(string filter)
        {
            yield return "Phone!";
        }
        IEnumerable<string> ISearch.Search(string filter)
        {
            yield return "Normal!";
        }
    }
