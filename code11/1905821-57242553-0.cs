c#
private static List<string> GetCellStrings(string cellRange)
{
    // Cell string to return from this method.
    List<string> cells = new List<string>();
    // Remove whitespace.
    cellRange = cellRange.Replace(" ", "").Trim();
    // First split by ',' to get subranges
    string[] subranges = cellRange.Split(',');
    // Iterate over subranges
    for (int i = 0; i < subranges.Length; i++)
    {
        string range = subranges[i];
        // If the subrange contains a ':', calculate all range cells
        if (range.Contains(':'))
        {
            string[] rangeBounds = range.Split(':');
            char lowerBoundLetter = rangeBounds[0][0];
            char upperBoundLetter = rangeBounds[1][0];
            int lowerBoundNumber = int.Parse(rangeBounds[0].Substring(1));
            int upperBoundNumber = int.Parse(rangeBounds[1].Substring(1));
            for (char columnLetter = lowerBoundLetter; columnLetter <= upperBoundLetter; columnLetter++)
            {
                for (int rowNumber = lowerBoundNumber; rowNumber <= upperBoundNumber; rowNumber++)
                {
                    string cell = columnLetter.ToString() + rowNumber.ToString();
                    cells.Add(cell);
                }
            }
        }
        // If the subrange does contains a ':', it is a single cell, add it to the list of cells
        else
        {
            cells.Add(range);
        }
    }
    return cells;
}
**Note:** This code works only for 26 column letters, A to Z.
Example:
c#
string cellRange = "D6:F11,I6:I9,J14,N10,P5:Q9";
List<string> cells = GetCellStrings(cellRange);
for (int i = 0; i < cells.Count; i++)
{
    Console.WriteLine(cells[i]);
}
Output:
D6
D7
D8
D9
D10
D11
E6
E7
E8
E9
E10
E11
F6
F7
F8
F9
F10
F11
I6
I7
I8
I9
J14
N10
P5
P6
P7
P8
P9
Q5
Q6
Q7
Q8
Q9
