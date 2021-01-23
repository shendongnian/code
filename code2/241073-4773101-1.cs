    static void Main()
    {
        List<A> listA = new List<A>{
                new A {Number =4},
                new A {Number =1},
                new A {Number =5}
        };
        Work(listA, a => a.Number);
    }
    public static void Work<T>(IList<T> list, Func<T, int> selector)
    {
        foreach (T obj in list)
        {
            int number = selector(obj);
            // do something with number;
        }
    }
