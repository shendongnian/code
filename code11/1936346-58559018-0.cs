    public class Finder : IFinder
    {
        public string FromRight(Customers customers, int numberFromRight)
        {
            return Unwind(customers).Reverse().Skip(numberFromRight - 1).FirstOrDefault()?.Person;
        }
        private static IEnumerable<Customers> Unwind(Customers customers)
        {
            while (customers != null)
            {
                yield return customers;
                customers = customers.Next;
            }
        }
    }
