c#
private static T Max<T>(IEnumerable<T> source) where T : IComparable<T>
{
  if (source == null)
    throw new ArgumentNullException(nameof(source));
  bool isMaxSet = false;
  T max;
  foreach (T item in source)
  {
    if (isMaxSet == false)
    {
      max = item;
      isMaxSet = true;
    }
    else
    {
      if (max.CompareTo(item) < 0) // here's where it's used!
        max = item;
    }
  }
  if (isMaxSet == false)
    throw new InvalidOperationException();
  return max;
}
