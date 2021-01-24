    public void printlocation(Object gameObject)
    {
        int heightToPrint = gameObject.GetHeight() % 10;
        for (int i = 100; i >= 0; i -= 10)
        {
            Console.WriteLine($"{i}m:{(i == heightToPrint ? "*" : "")}");
        }
    }
