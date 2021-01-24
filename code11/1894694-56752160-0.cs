        List<string> EmployeesList = new List<string>() { "Jim Carrey", "Uma Thurman", "Bill Gates", "Jon Skeet" };
        Dictionary<int, List<string>> employeesById = new Dictionary<int, List<string>>();
        Dictionary<string, List<int>> employeeIdsByName = new Dictionary<string, List<int>>();
        private void Init() // prepare our lists
        { 
            for (int i = 0; i < EmployeesList.Count; i++)
            {
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
        private List<SearchResult> FindEmployeeByNameFuzzy(string query)
        {
            var results = new List<SearchResult>();
            var searchterms = query.ToLower().Split(new char[] { ' ' });
            for (int i = 0; i < employeesById.Count; i++)
            {
                var r = new SearchResult() { Id = i, Name = EmployeesList[i] };
                var employee = employeesById[i];                
                foreach (var searchterm in searchterms)
                {
                    int min = searchterm.Length;
                    foreach (var name in employee)
                    {
                        var distance = LevenshteinDistance.Compute(searchterm, name);
                        min = Math.Min(min, distance);
                    }
                    r.Distance += min;
                }
                results.Add(r);
            }
            return results.OrderBy(e => e.Distance).ToList();
        }
    }
    public class SearchResult
    {
        public int Distance { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    static class LevenshteinDistance
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
