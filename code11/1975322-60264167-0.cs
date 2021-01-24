    class Program
    {
        static void Main(string[] args)
        {
            OldData oldData = new OldData
            {
                Name = "Pizza",
                OriginalPath = "Pozza"
            };
            NewData newData = new NewData
            {
                Name = "Pizza",
                OriginalPath = "Pozza"
            };
            var comparer = new CommonDataComparer();
            bool areEqual = comparer.Equals(oldData, newData);
            Console.WriteLine(areEqual);
        }
    }
    public interface ICommonData
    {
        public string Name { get; set; }
        public string OriginalPath { get; set; }
    }
    public class OldData : ICommonData
    {
        public string Name { get; set; }
        public string OriginalPath { get; set; }
    }
    public class NewData : ICommonData
    {
        public string Name { get; set; }
        public string OriginalPath { get; set; }
    }
    public class CommonDataComparer : IEqualityComparer<ICommonData>
    {
        public bool Equals([AllowNull] ICommonData x, [AllowNull] ICommonData y)
        {
            return ((x?.Name == y?.Name) && (x?.OriginalPath == y?.OriginalPath));
        }
        public int GetHashCode([DisallowNull] ICommonData obj)
        {
            return obj.Name.GetHashCode() + obj.OriginalPath.GetHashCode();
        }
    }
