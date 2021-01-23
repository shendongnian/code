    namespace SomeNamespace
    {
        public static class ListExtensions
        {
            public static void OutputAll(this IEnumerable<Employee> employees)
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine("{0}: {1}", employee.FirstName, employee.LastName);
                }
            }
        }
    }
