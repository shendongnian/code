int size=1000;
int iterations = (lastModifiedCustomers.Items.Count/size)+1;
List<Customer> customers = new List<Customer>();
for(int i=1;i<iterations;i++)
{
 foreach (CustomerSummary cs in lastModifiedCustomers.GetRange(i==1?i:(i-1)*size+1,i*size))
 {
    customers.Add(customerService.CallService(x => x.GetCustomerByKey(cs.Key, context)));
 }
}
 return customers;
