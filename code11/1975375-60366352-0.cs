public static List<string> AllPropertiesNotNull(IDictionary dictionary, string name, HashSet<object> alreadyChecked)
{
  List<string> nullValues = new List<string>();
  foreach(object key in dictionary.Keys)
  {
    object obj = dictionary[key];
    if (!alreadyChecked.Contains(obj))
    {
      string elementName = $"{name}[\"{key}\"]";
      nullValues.AddRange(AllPropertiesNotNull(obj, elementName, alreadyChecked));
    }
  }
  return nullValues;
}
public static List<string> AllPropertiesNotNull(IEnumerable enumerable, string name, HashSet<object> alreadyChecked)
{
  List<string> nullValues = new List<string>();
  int i = 0;
  foreach (object obj in enumerable)
  {
    if (!alreadyChecked.Contains(obj))
    {
      string elementName = $"{name}[{i}]";
      nullValues.AddRange(AllPropertiesNotNull(obj, elementName, alreadyChecked));
    }
    i++;
  }
  return nullValues;
}
public static List<string> AllPropertiesNotNull(object obj, string name, HashSet<object> alreadyChecked, string baseName = "")
{
  List<string> nullValues = new List<string>();
  string basePropertyName;
  if (string.IsNullOrEmpty(baseName))
  {
    basePropertyName = name;
  }
  else
  {
    basePropertyName = baseName + "." + name;
  }
  if (obj == null)
  {
    nullValues.Add(basePropertyName);
  }
  else if (!alreadyChecked.Contains(obj))
  {
    alreadyChecked.Add(obj);
    if (!obj.GetType().Equals(typeof(string)))
    {
      foreach (PropertyInfo property in obj.GetType().GetProperties())
      {
        object value = property.GetValue(obj);
        string propertyName = basePropertyName + "." + property.Name;
        if (value == null)
        {
          nullValues.Add(propertyName);
        }
        else
        {
          if (typeof(IDictionary).IsAssignableFrom(property.PropertyType))
          {
            nullValues.AddRange(AllPropertiesNotNull((IDictionary)value, propertyName, alreadyChecked));
          }
          else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
          {
            nullValues.AddRange(AllPropertiesNotNull((IEnumerable)value, propertyName, alreadyChecked));
          }
          else
          {
            nullValues.AddRange(AllPropertiesNotNull(value, property.Name, alreadyChecked, basePropertyName));
          }
        }
      }
    }
  }
  return nullValues;
}
I wrote some classes to test with:
class A
{
  public string s1 { set; get; }
  public string s2 { set; get; }
  public int i1 { set; get; }
  public int? i2 { set; get; }
  public B b1 { set; get; }
  public B b2 { set; get; }
}
class B
{
  public string s1 { set; get; }
  public string s2 { set; get; }
  public int i1 { set; get; }
  public int? i2 { set; get; }
  public A a1 { set; get; }
  public Dictionary<int, string> d1 { set; get; }
  public List<A> l1 { set; get; }
}
and tested it as follows:
A a = new A
{
  s1 = "someText"
};
B b = new B
{
  s1 = "someText",
  a1 = a,
  d1 = new Dictionary<int, string>
  {
    { 1, "someText" },
    { 2, null }
  },
  l1 = new List<A>{ null, new A { s1 = "someText" } , a }
};
a.b1 = b;
Console.WriteLine(string.Join("\n", AllPropertiesNotNull(a, nameof(a), new HashSet<object>())));
Output:
a.s2
a.i2
a.b1.s2
a.b1.i2
a.b1.d1["2"]
a.b1.l1[0]
a.b1.l1[1].s2
a.b1.l1[1].i2
a.b1.l1[1].b1
a.b1.l1[1].b2
a.b2
