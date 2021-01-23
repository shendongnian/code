    public static class MyExtensions 
    {
        public void AddToFront<T>(this List<T> list, T item)
        {
             // omits validation, etc.
             list.Insert(0, item);
        }
    }
    // elsewhere
    yourListOfStrings.AddToFront("foo");
