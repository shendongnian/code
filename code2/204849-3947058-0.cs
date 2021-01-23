    if (targetRange.Count = 1) 
    {
       object myValue = targetRange.Value;
       MessageBox.Show(myValue.ToString());
    }
    else
    {
        object[,] myArray = targetRange.Value;
        for(int row = 1; row < myValue.GetLength(0); row++)
        {
            for(int column = 1; column < myValue.GetLength(1); column++)
            {
                MessageBox.Show(myArray[row, column].ToString());
            }
        }
    }
