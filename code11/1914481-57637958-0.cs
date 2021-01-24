`
public MyClass()
{
  MethodInfo method = typeof(Foo).GetMethod("Setup", BindingFlags.Instance |
    BindingFlags.NonPublic | BindingFlags.Public);
  foreach (FieldInfo f in GetType().GetFields(BindingFlags.Instance |
    BindingFlags.NonPublic | BindingFlags.Public)
    .Where(fieldInfo => fieldInfo.FieldType.Equals(typeof(Foo))))
  {
    method.Invoke(f.GetValue(this), null);
  }
}
`
