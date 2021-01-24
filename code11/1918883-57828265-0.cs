c#
public class OracleDbFunctionExtensions
{
    public string Nvl(this DbFunction function, string string1, string replace_with) => throw new NotImplementedException(); // You can provide matching in-memory implementation for client-side evaluation of query if needed
}
register it in your DbContext
c#
protected overridevoid OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.HasDbFunction(typeof(OracleDbFunctionExtensions).GetMethod(nameof(OracleDbFunctionExtensions.Nvl, builder => 
    {
        builder.HasName("nvl");
    });
}
and use it in your `Where` expression as
c#
.Where(i => EF.Functions.Nvl(i.nullablecolumn, "N"))
You can also use attribute `DbFunctionAttribute` on `OracleDbFunctionExtensions.Nvl` to avoid registering it in `OnModelCreating`
