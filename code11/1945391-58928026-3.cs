static void Main(string[] args)
{
    int[,] arrayPart1 = new int[3, 4];
    for (int row = 0; row < arrayPart1.GetLength(0); row++)
    {
        for (int column = 0; column < arrayPart1.GetLength(1); column++)
        {
            arrayPart1[row, column] = Convert.ToInt32(Console.ReadLine());
        }
    }
    for (int row = 0; row < arrayPart1.GetLength(0); row++)
     {
          for (int column = 0; column < arrayPart1.GetLength(1); column++)
          {
                Console.Write("Value at [" + row + ", " + column + "]: " + arrayPart1[row, column] + "\t");
          }
          Console.WriteLine();
          Console.WriteLine("The highest value in the array is at "+ LocateLargest (arrayPart1).ToString ()) 
     }
}
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
    return largest; 
}
