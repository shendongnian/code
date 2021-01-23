    // Essentially unchanged from Eamon Nerbonne's version
    public static bool IsDefaultValue([CanBeNull] object a)
    {
      if (a == null) return true;
      Type type = a.GetType();
      return type.IsValueType &&
             helpers.GetOrAdd(
               type,
               t =>
               {
                 var method = typeof(StructHelpers<>).MakeGenericType(t)
                  .GetMethod(nameof(StructHelpers<int>.IsDefaultValue));
                 var objParam = Expression.Parameter(typeof(object), "obj");
                 return Expression.Lambda<Func<object, bool>>(
                     Expression.Call(method, Expression.Convert(objParam, t)),
                     objParam)
                  .Compile();
               })(a);
    }
    static readonly ConcurrentDictionary<Type, Func<object,bool>> helpers = 
      new ConcurrentDictionary<Type, Func<object,bool>>();
    static class StructHelpers<T> where T : struct
    {
      // ReSharper disable StaticMemberInGenericType
      static readonly int ByteCount = Unsafe.SizeOf<T>();
      static readonly int LongCount = ByteCount / 8;
      static readonly int ByteRemainder = ByteCount % 8;
      // ReSharper restore StaticMemberInGenericType
      public static bool IsDefaultValue(T a)
      { 
        if (LongCount > 0)
        {
          ref long p = ref Unsafe.As<T, long>(ref a);
          // Inclusive end - don't know if it would be safe to have a ref pointing
          // beyond the value as long as we don't read it
          ref long end = ref Unsafe.Add(ref p, LongCount - 1);
          do
          {
            if (p != 0) return false;
            p = ref Unsafe.Add(ref p, 1);
          } while (!Unsafe.IsAddressGreaterThan(ref p, ref end));
        }
        if (ByteRemainder > 0)
        {
          ref byte p = ref Unsafe.Add(
                         ref Unsafe.As<T, byte>(ref a),
                         ByteCount - ByteRemainder);
          ref byte end = ref Unsafe.Add(ref p, ByteRemainder - 1);
          do
          {
            if (p != 0) return false;
            p = ref Unsafe.Add(ref p, 1);
          } while (!Unsafe.IsAddressGreaterThan(ref p, ref end));
        }
        return true;
      }
    }
