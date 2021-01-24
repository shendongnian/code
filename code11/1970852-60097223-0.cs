using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//...
public partial class SQLiteEFDatabase : EFDatabase
{
   //...
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ConfigureValueConversions(modelBuilder);
    }
    //...
    private void ConfigureValueConversions(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(Guid))
                {
                    property.SetValueConverter(new GuidToBytesConverter());
                }
            }
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(new DateTimeToStringConverter());
                }
            }
        }
    }
}
Huge thanks to Jeremy for helping with this!!!
  [1]: https://stackoverflow.com/users/2457221/jeremy-sheeley
