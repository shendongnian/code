    public class OrderCreateViewModel
{
	
    //a whole bunch of order properties....
	public Cart OrderItems { get; set; }
	public int CustomerId { get; set; }
	
	//Different options
	public List<Customer> Customers { get; set; } //An option
	public string CustomerName { get; set; } //An option to use as a client side search
