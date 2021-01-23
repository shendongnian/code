    public static void ForEach2<T>(this T[] list, MyActionRef<T> actionRef)
    {
      if (actionRef == null)
        throw new ArgumentNullException("actionRef");
      for (int idx = 0; idx < list.Length; idx++)
      {
        actionRef(ref list[idx]);
      }
    }
