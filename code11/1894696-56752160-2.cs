    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace EmployeeSearch
    {
        static class Program
        {
            static List<string> EmployeesList = new List<string>() { "Jim Carrey", "Uma Thurman", "Bill Gates", "Jon Skeet" };
            static Dictionary<int, List<string>> employeesById = new Dictionary<int, List<string>>();
            static Dictionary<string, List<int>> employeeIdsByName = new Dictionary<string, List<int>>();
    
            static void Main()
            {
                Init();
                var results = FindEmployeeByNameFuzzy("Umaa Thurrmin");
                // Returns:
                // (1) Uma Thurman  Distance: 3
                // (0) Jim Carrey  Distance: 10
                // (3) Jon Skeet  Distance: 11
                // (2) Bill Gates  Distance: 12
                Console.WriteLine(string.Join("\r\n", results.Select(r => $"({r.Id}) {r.Name}  Distance: {r.Distance}")));
                var results = FindEmployeeByNameFuzzy("Tormin Oma");
                // Returns:
                // (1) Uma Thurman  Distance: 4
                // (3) Jon Skeet  Distance: 7
                // (0) Jim Carrey  Distance: 8
                // (2) Bill Gates  Distance: 9
                Console.WriteLine(string.Join("\r\n", results.Select(r => $"({r.Id}) {r.Name}  Distance: {r.Distance}")));
                Console.Read();
            }
    
            private static void Init() // prepare our lists
            {
                for (int i = 0; i < EmployeesList.Count; i++)
                {
                    // Preparing the list of names for each employee - add special cases such as hyphenation here as well
                    var names = EmployeesList[i].ToLower().Split(new char[] { ' ' }).ToList();
                    employeesById.Add(i, names);
    
                    // This is not used here, but could come in handy if you want a unique index of names pointing to employee ids for optimisation:
                    foreach (var name in names)
                    {
                        if (employeeIdsByName.ContainsKey(name))
                        {
                            employeeIdsByName[name].Add(i);
                        }
                        else
                        {
                            employeeIdsByName.Add(name, new List<int>() { i });
                        }
                    }
                }
    
            }
    
            private static List<SearchResult> FindEmployeeByNameFuzzy(string query)
            {
                var results = new List<SearchResult>();
                // Notice we're splitting the search terms the same way as we split the employee names above (could be refactored out into a helper method)
                var searchterms = query.ToLower().Split(new char[] { ' ' });
    
                // Comparison with each employee
                for (int i = 0; i < employeesById.Count; i++)
                {
                    var r = new SearchResult() { Id = i, Name = EmployeesList[i] };
                    var employeenames = employeesById[i];
                    foreach (var searchterm in searchterms)
                    {
                        int min = searchterm.Length;
    
                        // for each search term get the min distance for all names for this employee
                        foreach (var name in employeenames)
                        {
                            var distance = LevenshteinDistance.Compute(searchterm, name);
                            min = Math.Min(min, distance);
                        }
    
                        // Sum the minimums for all search terms
                        r.Distance += min;
                    }
                    results.Add(r);
                }
                // Order by lowest distance first
                return results.OrderBy(e => e.Distance).ToList();
            }
        }
    
        public class SearchResult
        {
            public int Distance { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public static class LevenshteinDistance
        {
            /// <summary>
            /// Compute the distance between two strings.
            /// </summary>
            public static int Compute(string s, string t)
            {
                int n = s.Length;
                int m = t.Length;
                int[,] d = new int[n + 1, m + 1];
    
                // Step 1
                if (n == 0)
                {
                    return m;
                }
    
                if (m == 0)
                {
                    return n;
                }
    
                // Step 2
                for (int i = 0; i <= n; d[i, 0] = i++)
                {
                }
    
                for (int j = 0; j <= m; d[0, j] = j++)
                {
                }
    
                // Step 3
                for (int i = 1; i <= n; i++)
                {
                    //Step 4
                    for (int j = 1; j <= m; j++)
                    {
                        // Step 5
                        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
    
                        // Step 6
                        d[i, j] = Math.Min(
                            Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                            d[i - 1, j - 1] + cost);
                    }
                }
                // Step 7
                return d[n, m];
            }
        }
    }
