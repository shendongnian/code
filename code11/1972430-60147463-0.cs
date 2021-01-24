int iterations = (lastModifiedCustomers.Items.Count/1000)+1;
List<Customer> customers = new List<Customer>();
for(int i=1;i<iterations;i++)
{
 foreach (CustomerSummary cs in lastModifiedCustomers.GetRange(i==1?i:(i-1)*1000+1,i*1000))
 {
    customers.Add(customerService.CallService(x => x.GetCustomerByKey(cs.Key, context)));
 }
}
 return customers;
