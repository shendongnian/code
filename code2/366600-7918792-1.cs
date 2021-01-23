    public interface IValueComparer
    {
        bool GreaterThan(string source, string destination);
        bool LessThan(string source, string destination);
    }
    public class IntToIntComparer : IValueComparer
    {
        public bool GreaterThan(string source, string detination)
        {
            // better use TryParse and handle exception
            return Int32.Parse(source) > Int32.Parse(detination);
        }
        public bool LessThan(string source, string detination)
        {
            // better use TryParse and handle exception
            return Int32.Parse(source) < Int32.Parse(detination);
        }
    }
    public class DateToDateComparer : IValueComparer
    {
        public bool GreaterThan(string source, string detination)
        {
            // better use TryParse and handle exception
            return DateTime.Parse(source) > DateTime.Parse(detination);
        }
        public bool LessThan(string source, string detination)
        {
            // better use TryParse and handle exception
            return DateTime.Parse(source) < DateTime.Parse(detination);
        }
    }
    public class StringToStringComparer : IValueComparer
    {
        public bool GreaterThan(string source, string detination)
        {
            return source.Length > detination.Length;
        }
        public bool LessThan(string source, string detination)
        {
            return source.Length < detination.Length;
        }
    }
    public class Condition
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public IValueComparer Comparer{get; set;}
        public static string Integer { get { return "Integer"; } }
        public static string String { get { return "String"; } }
        public static string DateTime { get { return "DateTime"; } }
        public static Condition CreateForType(string type)
        {
            if (type == Integer)
                return new Condition { Type = type, Comparer = new IntToIntComparer() };
            if (type == String)
                return new Condition { Type = type, Comparer = new StringToStringComparer() };
            if (type == DateTime)
                return new Condition { Type = type, Comparer = new DateToDateComparer() };
            return null;
        }
        public bool GreaterThan(Condition destination)
        {
            return Comparer.GreaterThan(Value, destination.Value);
        }
        public static bool operator >(Condition source, Condition destination)
        {
            return source.GreaterThan(destination);
        }
        public static bool operator <(Condition source, Condition destination)
        {
            return source.LessThan(destination);
        }
        public bool LessThan(Condition destination)
        {
            return Comparer.LessThan(Value, destination.Value);
        }
    }
----
            var condition1 = Condition.CreateForType("Integer");
            condition1.ID = 1;
            condition1.Value = "5";
            var condition2 = Condition.CreateForType("Integer");
            condition2.ID = 2;
            condition2.Value = "10";
            bool result1 = condition1 > condition2;
            bool result2 = condition1.LessThan(condition2);
