public class Catalog
{
    public int CatalogId { get; set; }
    public string CatalogName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsDeleted { get; set; }
}
public class CatalogExtension : Catalog
{
    public string YourCustomValue { get; set; }
    public CatalogExtension(Catalog catalog)
    {
        CatalogId = catalog.CatalogId;
        CatalogName = catalog.CatalogName;
        StartDate = catalog.StartDate;
        EndDate = catalog.EndDate;
        IsDeleted = catalog.IsDeleted;
        YourCustomValue = "test"
    }
    public CatalogExtension()
    {
        // Assign values however you want
    }
}
Then, you can get a new CatalogExtension object by:
var resp = new CatalogExtension(catalog);
or 
var resp = new CatalogExtension();
