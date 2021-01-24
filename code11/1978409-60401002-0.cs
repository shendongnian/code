c#
var output = new List<string>();
int totalRow = 3;
int totalCol = 10;
for (var i = 0; i < totalRow; i++)
{
    var lines = seats.Skip(i * totalCol).Take(totalCol)
        .Select(seat => $"Row: {seat.Row}. Col: {seat.Col}. Status: {seat.Status}");
    output.Add(string.Join(" ", lines));
}
Console.WriteLine(string.Join("\n", output));
