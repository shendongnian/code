    [HttpPut]
    public JsonResult UpdateCustomerValues(string email, CustomerUpdateRequest request)
    {
    	var customer = new Customer();
    	customer.Email=email;
    	PropertyInfo propertyInfo = customer.GetType().GetProperty(request.propertyName);
    	propertyInfo.SetValue(customer, Convert.ChangeType(request.value, propertyInfo.PropertyType), null);
    
    }
    public class CustomerUpdateRequest
    {
        public string propertyName{get;set;}
        public string value{get;set;}
    
    }
