`
// Taken from: https://gist.github.com/jonathanconway/3330614
public static bool IsSimpleType(this Type type)
{
  return
    type.IsValueType ||
    type.IsPrimitive ||
    new Type[] {
    typeof(String),
    typeof(Decimal),
    typeof(DateTime),
    typeof(DateTimeOffset),
    typeof(TimeSpan),
    typeof(Guid)
    }.Contains(type) ||
    Convert.GetTypeCode(type) != TypeCode.Object;
}
public static bool DeepCompare<T>(this T obj1, T obj2)
{
  if(obj1.GetType().IsSimpleType())
  {
    return obj1.Equals(obj2);
  }
  
  foreach(var member in typeof(T).GetMembers().Where(m => m.MemberType.Equals(MemberTypes.Field) || m.MemberType.Equals(MemberTypes.Property)))
  {
    Type t = member.MemberType.Equals(MemberTypes.Field) ?
      ((FieldInfo)member).FieldType :
      ((PropertyInfo)member).PropertyType;
    Func<object, object> getter = member.MemberType.Equals(MemberTypes.Field) ?
      new Func<object, object>(((FieldInfo)member).GetValue) :
      new Func<object, object>(((PropertyInfo)member).GetValue);
    if(t.GetInterface("IEnumerable") != null)
    {
      var obj1Iterator = ((IEnumerable)getter(obj1)).GetEnumerator();
      var obj2Iterator = ((IEnumerable)getter(obj2)).GetEnumerator();
      bool has1 = obj1Iterator.MoveNext(), has2 = obj2Iterator.MoveNext();
      while(has1 && has2)
      {
        if(!DeepCompare(obj1Iterator.Current, obj2Iterator.Current))
        {
          return false;
        }
        has1 = obj1Iterator.MoveNext();
        has2 = obj2Iterator.MoveNext();
      }
      if(has1 != has2)
      {
        return false;
      }
    }
    else
    {
      if(!DeepCompare(getter(obj1), getter(obj2)))
      {
        return false;
      }
    }
  }
  return true;
}
`
