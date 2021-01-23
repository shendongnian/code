    public static class MyExtensions 
    {
        public static void AddToFront<T>(this List<T> list, T item)
        {
             // omits validation, etc.
             list.Insert(0, item);
        }
    }
    // elsewhere
    List<int> list = new List<int>();
    list.Add(2);
    list.AddToFront(1);
    // list is now 1, 2
