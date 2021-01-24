# Read data
var data = new SortedDictionary<(string id, string idr, string email), List<(string reference, decimal amount)>>();
using (var input = File.OpenText("input.txt"))
{
    List<(string reference, decimal amount)> currentInvoice = null;
    for (var line = input.ReadLine(); line != null; line = input.ReadLine())
    {
        var fields = line.Split(new char[] { '@' }, 6);
        switch (fields.Length)
        {
            case 2:
                // Sanitize input
                if (fields[0] != "INV")
                {
                    throw new Exception("Unknown record type.");
                }
                if (currentInvoice == null)
                {
                    throw new Exception("Invoice without context.");
                }
                // Parse
                var invoiceEntry = fields[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (invoiceEntry.Length == 2)
                {
                    decimal amount;
                    if (decimal.TryParse(invoiceEntry[1],
                        NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                        CultureInfo.InvariantCulture,
                        out amount))
                    {
                        currentInvoice.Add((invoiceEntry[0], amount));
                    }
                }
                break;
            case 6:
                var currentContext = (id: fields[0], idr: fields[2], email: fields[5]);
                if (!data.TryGetValue(currentContext, out currentInvoice))
                {
                    currentInvoice = new List<(string reference, decimal amount)>();
                    data.Add(currentContext, currentInvoice);
                }
                break;
            default:
                throw new Exception("Unknown record.");
        }
    }
}
# Print data
foreach (var customerData in data.Keys.GroupBy(x => (x.id, x.idr), x => x.email))
{
    Console.WriteLine(String.Join("|",
        "0",
        customerData.Key.id,
        customerData.Key.idr,
        data.Where(x => x.Key.id == customerData.Key.id && x.Key.idr == customerData.Key.idr).Sum(x => x.Value.Sum(d => d.amount)),
        customerData.Count()
        ));
    foreach (var email in customerData)
    {
        Console.WriteLine(String.Join("|",
            "1",
            customerData.Key.id,
            email
            ));
        foreach (var invoiceEntry in data[(customerData.Key.id, customerData.Key.idr, email)])
        {
            Console.WriteLine(String.Join("|",
                "2",
                invoiceEntry.reference,
                invoiceEntry.amount.ToString("n0")
                ));
        }
    }
}
I would also point out some inconsistencies in your data; if they are intentional, the algorithm may need to be adjusted accordingly:
- customer DEF has its email separated by | instead of @ (I assumed it's an example mistake),
- invoice entries use thousand separators, but totals at customer level do not (this is only affecting output, as totals are calculated from invoice entries, not taken from customer row),
- most important: totals do not add up; total for DEF customer is 100186050, not 100186049. You may want to pay more attention to this.
