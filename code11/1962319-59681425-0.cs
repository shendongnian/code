this.cmbmonth.FormatString = "yyyy/ MM/dd"
Anyway, you should always check dates passed as string, and throw an exception if you can't cast them:
if (!DateTime.TryParse(_date, out DateTime date))
{
    throw new InvalidCastException("Not a valid date.");
}
And last, try to set you SqlCommand parameters this way, is more readable and you don't have to deal with string interpolation (checkout for:
using (DbConnection connection = new SqlConnection("MyConnectionString"))
{
    using (DbCommand command = new SqlCommand(connection))
    {
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT * FROM MyTable WHERE Date = @Date";
        command.Parameters.Add("@Date", SqlDbType.Date);
        command.Parameters["@Date"].Value = date;
    }
}
Give it a try! :)
Regards!
