    Interface MyEnumerator<T>
    {
        public T GetNext();
    }
    public static class MyEnumeratorExtender
    {
        public static void MyForeach<T>(this MyEnumerator<T> enumerator,
            Action<T> action)
        {
            T item = enumerator.GetNext();
            while (item != null)
            {
                action.Invoke(item);
                item = enumerator.GetNext();
            }
        }
    }
