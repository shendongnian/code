csharp
public List<TaskProdEntity> ParseCSVFile()
{
    using (var reader = new StreamReader(@"C:\Users\me\Desktop\pfile.csv"))
    using (var csv = new CsvReader(reader))
    {
        csv.Configuration.PrepareHeaderForMatch = (string header, int index) =>
            header.Replace(" ", "_").Replace("(", "").Replace(")", "").Replace(".", "");
        List<TaskProdEntity> records = new List<TaskProdEntity>();
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {
            if (csv.GetField<int>(0) == 1)
            {
                var record = new TaskProdEntity
                {
                    Identifier = "ID Number:" + " " + csv.GetField<string>("Id"),
                    Region = GetAddress(csv),
                    Program = "Taxonomy Group:" + " " + csv.GetField<string>("Taxonomy_Group_1")
                };
                records.Add(record);
            }
            else
            {
                var record = new TaskProdEntity
                {
                    Identifier = "ID Number:" + " " + csv.GetField<string>("Id3"),
                    Region = GetAddress(csv, "2"),
                    Program = "Taxonomy Group:" + " " + csv.GetField<string>("Taxonomy_Group_2")
                };
                records.Add(record);
            }
        }
        return records;
    }
}
private string GetAddress(CsvReader csv, string extension = "")
{
    var value = new StringBuilder("Business Mailing Address:");
    if (csv.GetField<string>("Provider_First_Line_Business_Mailing_Address" + extension) != string.Empty)
    {
        value.Append(" " + csv.GetField<string>("Provider_First_Line_Business_Mailing_Address" + extension));
    }
    if (csv.GetField<string>("Provider_Second_Line_Business_Mailing_Address" + extension) != string.Empty)
    {
        value.Append(" " + csv.GetField<string>("Provider_Second_Line_Business_Mailing_Address" + extension));
    }
    // The rest of the if statements..............
    return value.ToString();
}
