     sm_compare_values_info = typeof(YourType).GetMethod("CompareValuesInternal", BindingFlags.NonPublic | BindingFlags.Static);
    static public bool CompareValues(object x, object y)
    {
      bool result = true;
      if ((x == null && y != null) || (x != null && y == null))
      {
        result = false;
      }
      else if (x == null && y == null)
      {
        result = true;
      }
      else if (x is IComparer)
      {
        result = ((x as IComparer).Compare(x, y) == 0);
      }
      else if (x is IComparable)
      {
        result = ((x as IComparable).CompareTo(y) == 0);
      }
      else if (x is IEqualityComparer)
      {
        result = (x as IEqualityComparer).Equals(x, y);
      }
      else if (x.GetType() != y.GetType())
      {
        result = false;
      }
      else
      {
        //----IMPORTANT PART----
        MethodInfo info = sm_compare_values_info.MakeGenericMethod(x.GetType());
        result = (bool)info.Invoke(null, new object[] { x, y });
      }
      return result;
    }
    static protected bool CompareValuesInternal<T>(T x, T y)
    {
      bool result = false;
      if (x is IEqualityComparer<T>)
      {
        result = (x as IEqualityComparer<T>).Equals(x, y);
      }
      else if (x is IEquatable<T>)
      {
        result = (x as IEquatable<T>).Equals(y);
      }
      else if (x is IComparable<T>)
      {
        result = ((x as IComparable<T>).CompareTo(y) == 0);
      }
      else if (x is IComparer<T>)
      {
        result = ((x as IComparer<T>).Compare(x, y) == 0);
      }
      
      return result;
    }
