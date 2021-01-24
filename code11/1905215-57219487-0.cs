        foreach (var getData in phoneBook)
        {
            if (name1.Contains(getData.Key))
            {
                Console.WriteLine(getData.Key + " = " + getData.Value);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
