        for (int i = 0; i < status.Length; i++)
        {
            if (status[i] > 0)
            {
                for (int j = 0; j < status[i]; j++)
                    Console.WriteLine(i);
            }
        }
        //or more easier using LINQ
        var result = status.SelectMany((i, index) => Enumerable.Repeat(index, i));
