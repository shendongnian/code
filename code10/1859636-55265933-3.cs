[Table(Name = "Products")]
public class ProductEntity
{
    // your other columns...
    [NotMapped]
    public bool ActiveListing {
        get
        {
            bool result = false;
            // your logic to calculate then set to "result" variable
            return result;
        }
    }
}
but if you need to store it, change the name of ActiveListing property, then manually assign to the final ActiveListing property before you will create or update the record. Example:
[Table(Name = "Products")]
public class ProductEntity
{
    // your other columns...
    [NotMapped]
    public bool CalculateActiveListing
    {
        get
        {
            bool result = false;
            // your logic to calculate then set to "result" variable
            return result;
        }
    }
    public bool ActiveListing { get; set; }
}
here an example if you have a navigation property to SalesRecords. important have Lazy Loading enabled, or use the Include() method.
    [NotMapped]
    public bool CalculateActiveListing
    {
        get
        {
            bool result = false;
            // your logic to calculate then set to "result" variable.
            // for example:
            // validate SalesRecords has data
            if (this.SalesRecords != null)
            {
                var sale = this.SalesRecords
                    .Where(ah => ah.Date <= GlobalCoordinatedDateTime.Local)
                    .Where(ah => ah.ProductModelNumber == ModelNumber && ah.ProductSerialNumber == SerialNumber)
                    .OrderByDescending(ah => ah.Date)
                    .FirstOrDefault();
                // sale exists
                if (sale != null)
                {
                    result = sale.Status == Statuses.Active;
                }
            }
            return result;
        }
    }
another example using your DbContext:
    [NotMapped]
    public bool CalculateActiveListing
    {
        get
        {
            bool result = false;
            // your logic to calculate then set to "result" variable.
            // for example:
            using (var context = new MyDbContext())
            {
                var sale = context.SalesRecords
                    .Where(ah => ah.Date <= GlobalCoordinatedDateTime.Local)
                    .Where(ah => ah.ProductModelNumber == ModelNumber && ah.ProductSerialNumber == SerialNumber)
                    .OrderByDescending(ah => ah.Date)
                    .FirstOrDefault();
                // sale exists
                if (sale != null)
                {
                    result = sale.Status == Statuses.Active;
                }
            }
            return result;
        }
    }
sorry, my bad english.
