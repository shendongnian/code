    private void Example()
    {
        DataTable dt = GetDataFromDb() // get data from database...
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Console.WriteLine((DateTime)dt.GetValueSafely<DateTime>("SomeDateColumn", i));
            Console.WriteLine((int)dt.GetValueSafely<int>("SomeIntColumn", i));
            Console.WriteLine((string)dt.GetValueSafely<string>("SomeStringColumn", i));
        }
    }
