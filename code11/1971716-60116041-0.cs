csharp
public class Program
{
    public static void Main(string[] args)
    {
        using (MemoryStream stream = new MemoryStream())
        using (StreamWriter writer = new StreamWriter(stream))
        using (StreamReader reader = new StreamReader(stream))
        using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            writer.WriteLine("col1,col2,col3,col4");
            writer.WriteLine("name1,empId1,241682-27638-USD-CIGGNT ,1");
            writer.WriteLine("name2,empId2,241682-27638-USD-OCGGINT ,1");
            writer.WriteLine("name3,empId3,241942-37190-USD-GGDIV ,2");
            writer.WriteLine("name4,empId4,241942-37190-USD-CHYOF ,1");
            writer.Flush();
            stream.Position = 0;
            sbyte[] ColumnIndex = { (int)MyEnum.col1, (int)MyEnum.col2, (int)MyEnum.col3, (int)MyEnum.col4 };
            int conversion = (int)MyEnum.col3;
            var myIndex = ColumnIndex[conversion];
            List<string> result = new List<string>();
            while (csv.Read())
            {
                result.Add(csv.GetField(myIndex));
            }
                
        }
            
    Console.ReadKey();
    }
}
public enum MyEnum
{
    col1,
    col2,
    col3,
    col4
}
