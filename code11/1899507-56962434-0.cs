`
public static void Main(string[] args)
{
      MethodInfo endpointMethod = typeof(Main).GetMethod("EndpointMethod").MakeGenericMethod(typeof(int)); //Replace Main with your class name
      object requestedList = endpointMethod.Invoke(null, null);
      var result = typeof(Main).GetMethod("Filter").MakeGenericMethod(requestedList.GetType().GetGenericArguments().First()).Invoke(null, new object[]{ requestedList });  //Replace Main with your class name
}
public static IEnumerable<T> Filter<T>(IEnumerable<T> inputList)
{
  return inputList;
}
public static IEnumerable<T> EndpointMethod<T>()
{
  IEnumerable<T> list = new List<T>();
  return list;
}
`
