csharp
public static void Main(string[] args)
{
    using (MemoryStream stream = new MemoryStream())
    using (StreamWriter writer = new StreamWriter(stream))
    using (StreamReader reader = new StreamReader(stream))
    using (CsvReader csv = new CsvReader(reader))
    {
        writer.WriteLine("DateTime,DateTimeNullable");
        writer.WriteLine("5/4/2019,");
        writer.WriteLine(",5/5/2019");
        writer.Flush();
        stream.Position = 0;
        csv.Configuration.TypeConverterCache.AddConverter<DateTime>(new DateFieldConverter());
        csv.Configuration.TypeConverterCache.AddConverter<DateTime?>(new DateFieldNullableConverter());
        var dataTable = new DataTable();
        dataTable.Columns.Add("DateTime", typeof(DateTime)).AllowDBNull = false;
        dataTable.Columns.Add("DateTimeNullable", typeof(DateTime)).AllowDBNull = true;
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {
            var row = dataTable.NewRow();
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.DataType == typeof(DateTime) && column.AllowDBNull)
                {
                    row[column.ColumnName] = csv.GetField(typeof(DateTime?), column.ColumnName);
                }
                else
                {
                    row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                }                        
            }
            dataTable.Rows.Add(row);
        }                
    }
}
public class DateFieldConverter : DateTimeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        bool result = DateTime.TryParse(text, out DateTime ret);
        if (result) return ret;
        return DateTime.MinValue;
    }
}
public class DateFieldNullableConverter : DateTimeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        bool result = DateTime.TryParse(text, out DateTime ret);
        if (result) return ret;
        return DBNull.Value;
    }
}
  [1]: https://github.com/JoshClose/CsvHelper/issues/1227
  [2]: https://stackoverflow.com/questions/21257827/how-to-add-csvhelper-records-to-datatable-to-use-for-sqlbulkcopy-to-the-database/46183713#46183713
