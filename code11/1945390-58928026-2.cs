int LocateLargest(int[,] someArray)
{
    int largest = someArray[0, 0];
    int row, column;
    int maxRow = 0;
    int maxCol = 0;
    for (row = 0; row < someArray.GetLength(0); row++)
    {
        for (column = 0; column < someArray.GetLength(1); column++)
         {
            if (someArray[row, column] > largest)
            {
                maxRow = row;
                maxCol = column;
                largest = someArray[row, column];
         }
     }
     Console.WriteLine("The largest value is at row " + maxRow.ToString() +  "and column " + maxCol.ToString());
}
