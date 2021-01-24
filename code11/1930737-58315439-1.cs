/// <summary>
/// Get a value from a string and return true if success
/// else return false if not convertible
/// </summary>
/// <typeparam name="T">The generic type parameter</typeparam>
/// <param name="str">The string to convert</param>
/// <param name="value">The value to get</param>
/// <returns>The converted value if success else the default of the type</returns>
public bool GetValueFromString<T>(string str, out T value)
  where T : IConvertible
{
  try
  {
    value = (T)Convert.ChangeType(str, typeof(T));
    return true;
  }
  catch
  {
    value = default(T);
    return false;
  }
}
Test:
void Test()
{
  int valueInt = 0;
  double valueDouble = 0;
  Console.WriteLine("DataIsValid<int>(text) : " + GetValueFromString("text", out valueInt));
  Console.WriteLine("DataIsValid<int>(-4) : " + GetValueFromString("-4", out valueInt));
  Console.WriteLine("DataIsValid<int>(4) : " + GetValueFromString("4", out valueInt));
  Console.WriteLine("DataIsValid<int>(4,3) : " + GetValueFromString("4,3", out valueInt));
  Console.WriteLine("DataIsValid<double>(text) : " + GetValueFromString("text", out valueDouble));
  Console.WriteLine("DataIsValid<double>(-4) : " + GetValueFromString("-4", out valueDouble));
  Console.WriteLine("DataIsValid<double>(4) : " + GetValueFromString("4", out valueDouble));
  Console.WriteLine("DataIsValid<double>(4,3) : " + GetValueFromString("4,3", out valueDouble));
}
Output:
    DataIsValid<int>(text) : False
    DataIsValid<int>(-4) : True
    DataIsValid<int>(4) : True
    DataIsValid<int>(4,3) : False
    DataIsValid<double>(text) : False
    DataIsValid<double>(-4) : True
    DataIsValid<double>(4) : True
    DataIsValid<double>(4,3) : True
