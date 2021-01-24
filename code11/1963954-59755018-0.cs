    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
    
    public class CustomerRepository : IRepository<Customer>
    {
        public IEnumerable<Customer> GetAll()
        {
            foreach (var line in this.data)
            {
                string[] CustomerData = Regex.Split(line, @"\s+(?=002#)");
                foreach (var CustomerItem in CustomerData)
                {
                    string[] d = Regex.Split(CustomerItem, "#");
                    yield return new Customer() { BusinessArea = d[3], CNPJ = d[1], Name = d[2] };
                }
            }
        }
    }
