    class UserLanguage
    {
        public string UserName { get; set; }
        public string Language { get; set; }
    }
    static class EnumerableExtensions
    {
        public static string Concatenate(this IEnumerable<string> source, string delimiter)
        {
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    StringBuilder builder = new StringBuilder(enumerator.Current);
                    while (enumerator.MoveNext())
                    {
                        builder.Append(delimiter).Append(enumerator.Current);
                    }
                    return builder.ToString();
                }
                else
                {
                    return null;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // assuming that you already have data stored in a structure similar to this
            var rawData = new List<UserLanguage>()
            {
                new UserLanguage { UserName = "Bob", Language = "English" },
                new UserLanguage { UserName = "Bob", Language = "French" },
                new UserLanguage { UserName = "Alan", Language = "Italian" },
                new UserLanguage { UserName = "Alan", Language = "Spanish" },
                new UserLanguage { UserName = "Alan", Language = "German" },
            };
            // group these objects together by UserName
            var groupedData = rawData.GroupBy(userLanguage => userLanguage.UserName);
            foreach (var grouping in groupedData)
            {
                Console.WriteLine(grouping.Key + "\t" + grouping.Select(userLanguage => userLanguage.Language).Concatenate("/"));
            }
        }
    }
