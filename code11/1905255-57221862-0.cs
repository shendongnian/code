c#
class ExcelCell
{
    public object Value2 { get; set; }
}
internal static void Main(string[] args)
{
    ExcelCell[,] cells = new ExcelCell[2, 2]
        {
            {
                new ExcelCell() { Value2 = 1 },
                new ExcelCell() { Value2 = 2 },
            },
            {
                new ExcelCell() { Value2 = 3 },
                new ExcelCell() { Value2 = 4 },
            }
        };
    Console.WriteLine("cells[0, 0].Value2: " + cells[0, 0].Value2);
    // cells[0,0]++ // won't work. Because you try to increment an object.
    // You have to unbox the object into it's actual type..
    int? x = cells[0, 0].Value2 as int?;
    if (x.HasValue) // if this works..
    {
        x++; // you can increment it..
        cells[0, 0].Value2 = x; // and put it back in place..
    }
    Console.WriteLine("cells[0, 0].Value2: " + cells[0, 0].Value2);
}
