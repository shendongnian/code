    // have you overriden Equals/GetHashCode?
    IEnumerable<Customer> resultsA = listA.Except(listB);
    // no override of Equals/GetHashCode? Can you provide an IEqualityComparer<Customer>?
    IEnumerable<Customer> resultsB = listA.Except(listB, new CustomerComparer()); // Comparer shown below
    // no override of Equals/GetHashCode + no IEqualityComparer<Customer> implementation?
    IEnumerable<Customer> resultsC = listA.Where(a => !listB.Any(b => b.Id == a.Id));
    // are the lists particularly large? perhaps try a hashset approach 
    HashSet<int> customerIds = new HashSet<int>(listB.Select(b => b.Id).Distinct());
    IEnumerable<Customer> resultsD = listA.Where(a => !customerIds.Contains(a.Id));
...
    class CustomerComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            return x.Id.Equals(y.Id);
        }
        public int GetHashCode(Customer obj)
        {
            return obj.Id.GetHashCode();
        }
    }
