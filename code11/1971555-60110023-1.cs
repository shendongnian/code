cs
var invoices = new List<Invoice>();
var result = invoices.GroupBy(i => new InvoiceHeader
{
	DocumentDate = i.DocumentDate,
	DocumentNumber = i.DocumentNumber,
	DocumentReference = i.DocumentReference
}).ToDictionary(g => g.Key, g => g.Select(i => new InvoiceHierarchi
{
	Certificate = i.Certificate,
	SerialNumber = i.SerialNumber,
	ProductCode = i.ProductCode,
	Description = i.Description
}).ToList());
Another option is to use [`ToLookup`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolookup?view=netframework-4.8#System_Linq_Enumerable_ToLookup__3_System_Collections_Generic_IEnumerable___0__System_Func___0___1__System_Func___0___2__) method
cs
var anotherResult = invoices.ToLookup(i => new InvoiceHeader
	{
		DocumentDate = i.DocumentDate,
		DocumentNumber = i.DocumentNumber,
		DocumentReference = i.DocumentReference
	},
	i => new InvoiceHierarchi
	{
		Certificate = i.Certificate,
		SerialNumber = i.SerialNumber,
		ProductCode = i.ProductCode,
		Description = i.Description
	});
`Lookup` represents a collection of keys each mapped to one or more values.
