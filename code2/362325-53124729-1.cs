    public void NewEnumValue(int i, string v)
    {
        try
        {
            string test = d[i];
            Console.WriteLine("This Key is already assigned with value: " + 
                               test);
        }
        catch
        {
            d.Add(i,v);
        }
    }
