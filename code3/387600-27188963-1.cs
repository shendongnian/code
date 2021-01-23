    public static void ForEach3<T>(this IList<T> list, MyActionRef<T> actionRef)
    {
      if (actionRef == null)
        throw new ArgumentNullException("actionRef");
      for (int idx = 0; idx < list.Count; idx++)
      {
        var temp = list[idx];
        actionRef(ref temp);
        list[idx] = temp;
      }
    }
