public IEnumerable<Order> UpdateOrdersByCustomer(int customerId, string effectiveDate)  //changed datatype of effectiveDate to string
{
    //converting string to DateTime? type
    DateTime? effDate = string.IsNullOrEmpty(effectiveDate) ? default(DateTime?) : DateTime.Parse(str);
    // do some logic with date obtained above
}
  [1]: http://msdn.microsoft.com/en-us/library/system.type.isprimitive(v=vs.110).aspx
