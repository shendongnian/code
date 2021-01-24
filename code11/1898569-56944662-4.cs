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
public static bool CompareIEnumerable(IEnumerable enumerable1, IEnumerable enumerable2)
{
  //if one is null and the other is not, they are not equal
  if(enumerable1 != null ^ enumerable2 != null)
  {
    return false;
  }
  //else if both are null, they are equal
  else if(enumerable1 == null && enumerable2 == null)
  {
    return true;
  }
  var obj1Iterator = enumerable1.GetEnumerator();
  var obj2Iterator = enumerable2.GetEnumerator();
  bool has1 = obj1Iterator.MoveNext(), has2 = obj2Iterator.MoveNext();
  //loop through the enumerables
  while (has1 && has2)
  {
    //compare the values deeply
    if (!DeepCompare(obj1Iterator.Current, obj2Iterator.Current))
    {
      return false;
    }
    has1 = obj1Iterator.MoveNext();
    has2 = obj2Iterator.MoveNext();
  }
  // if the loop terminated and has1 != has2, one of them have more items, the are not equal
  return has1 == has2;
}
public static bool DeepCompare<T>(this T obj1, T obj2)
{
  //if one is null and the other is not, they are not equal
  if(obj1 != null ^ obj2 != null)
  {
    return false;
  }
  //else if both are null, they are equal
  else if(obj1 == null && obj2 == null)
  {
    return true;
  }
  Type objectsType = obj1.GetType();
  //if they are a simple type, compare them using .Equals method
  if (objectsType.IsSimpleType())
  {
    return obj1.Equals(obj2);
  }
  //if they are a simple type, compare them using CompareIEnumerable method
  else if(objectsType.GetInterface("IEnumerable") != null)
  {
    return CompareIEnumerable((IEnumerable)obj1, (IEnumerable)obj2);
  }
  //The type is not simple nor IEnumerable, loop through the properties and check if they are equal (Deeply)
  foreach (var member in objectsType.GetMembers().Where(m => m.MemberType.Equals(MemberTypes.Field) || m.MemberType.Equals(MemberTypes.Property)))
  {
    Type t = member.MemberType.Equals(MemberTypes.Field) ?
      ((FieldInfo)member).FieldType :
      ((PropertyInfo)member).PropertyType;
    Func<object, object> getter = member.MemberType.Equals(MemberTypes.Field) ?
      new Func<object, object>(((FieldInfo)member).GetValue) :
      new Func<object, object>(((PropertyInfo)member).GetValue);
    //if the member type is IEnumerable, compare them using CompareIEnumerable method
    if (t.GetInterface("IEnumerable") != null)
    {
      if(!CompareIEnumerable((IEnumerable)getter(obj1), (IEnumerable)getter(obj2)))
      {
        return false;
      }
    }
    //else, compare them Deeply
    else
    {
      if (!DeepCompare(getter(obj1), getter(obj2)))
      {
        return false;
      }
    }
  }
  return true;
}
`
