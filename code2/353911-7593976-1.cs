    public static void Output<T>(IEnumerable<T> dataSource) where T : class
    {   
        dataSourceName = (typeof(T).Name);
        if(string.Compare(dataSourceName, typeof(CustomerDetails).Name.ToString(), true)==0)
        {
            var t = 123;
        }
        else if (/*case 2 conditional*/)
        {
            //blah
        }
        else
        {
            //default case
            Console.WriteLine("Test");
        }
    }
