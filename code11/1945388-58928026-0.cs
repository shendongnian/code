int LocateLargest(int[,] someArray)
{
    int largest = someArray[0, 0];
    int row, column;
    for (row = 0; row < someArray.GetLength(0); row++)
    {
        for (column = 0; column < someArray.GetLength(1); column++)
         {
            if (someArray[row, column] > largest)
                largest = someArray[row, column];
         }
     }
     Console.WriteLine("The largest value is at row " + row.ToString() +  "and column " + column.ToString());
}
