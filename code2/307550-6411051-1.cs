    int numberRows = dataArray.GetUpperBound(0);
    int numberColumns = dataArray.GetUpperBound(1);
    for (int i = 0; i <= numberRows ; i++)
    {
        for (int j = 0; j <= numberColumns ; j++)
        {
            Console.WriteLine(string.Format("({0,8}) ", dataArray[i, j]));
        }
	Console.WriteLine();
    }
