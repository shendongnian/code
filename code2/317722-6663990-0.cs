    //untested
    public static void MoveDown(this IList<T> list, int index)  
    {
       if (index >= list.Count) ... // error
       if (index > 0)
       {
           var temp = list[index];
           list.RemoveAt(index);
           list.Insert(index - 1, temp);
       }
    }
