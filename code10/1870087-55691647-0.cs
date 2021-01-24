private IMarkerInterface getIMF(string str) 
{
    IMarkerInterface value = null;
    Properties?.TryGetValue(_string, out value);
    return value;
}
 
public _ReturnType _PropertyName
    {
      get { return getIMF(_string) as _ReturnType; }
      set { Properties[_string] = value; }
    }
