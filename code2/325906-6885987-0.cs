    private static void Visit(ref Expression left, ref Expression right)
    {
      if (Type.GetTypeCode(left.Type) > Type.GetTypeCode(right.Type))
      {
         right = Expression.Convert(right, left.Type);
      }
      else
      {
         left = Expression.Convert(left, right.Type);
      }
    }
