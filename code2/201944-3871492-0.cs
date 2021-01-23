    static void test(IEnumerable<object> objects)
    {
        while (objects.Any())
        {
            foreach (object o in objects.Take(100))
            {
            }
            objects = objects.Skip(100); 
        }
    }
:)
