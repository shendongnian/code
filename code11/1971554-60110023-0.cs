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
