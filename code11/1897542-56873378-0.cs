    public ObservableCollection<Customer> Customers { get; } = new ObservableCollection<Customer>();
    ...
    private void GetCustomers()
    {
        Customers.Clear();
        using (var context = new mainEntities())
        {
            var result = context.customerassigned.Where(c => c.user_id == User.Id).Include(c => c.customer).Where(c=>c.customer.status_id == 1);
            foreach (var item in result)
            {
                Customers.Add(new Customer(item.customer.id, item.customer.name, item.customer.status_id));
            }
        }
    }
