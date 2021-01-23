    private void Example()
    {
        DataTable dt = GetDataFromDb() // get data from database...
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Console.WriteLine(dt.GetValueSafely<DateTime>("SomeDateColumn", i));
            Console.WriteLine(dt.GetValueSafely<int>("SomeIntColumn", i));
            Console.WriteLine(dt.GetValueSafely<int>("SomeStringColumn", i));
        }
    }
