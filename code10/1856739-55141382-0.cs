 sql
WHERE (FirstName = @FirstName OR (@FirstName IS NULL AND FirstName IS NULL))
AND (LastName = @LastName OR (@LastName IS NULL AND LastName IS NULL))
-- etc x5
(or whatever test you want to perform for nulls) - and use something like:
 c#
database.sqlCommand.Parameters.AddWithValue("@FirstName", txbFirstName.Text.DBNullIfEmpty());
database.sqlCommand.Parameters.AddWithValue("@LastName", txbLastName.Text.DBNullIfEmpty());
// etc x5
where `DBNullIfEmpty` would look something like:
 c#
internal static class MyExtensionMethods
{
    public static object DBNullIfEmpty(this string value)
    {
        if(string.IsNullOrWhiteSpace(value)) return DBNull.Value;
        return value;
    }
}
