public int padding_TopTitle
{
  get 
  { 
    return paddingTopTitle; 
  }
  set 
  { 
    if ( paddingTopTitle != value )
    {
      paddingTopTitle = value; 
      Refresh(); 
    }
  }
}
You may consider using [Framework Design Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/):
public int PaddingTopTitle
{
  get 
  { 
    return paddingTopTitle; 
  }
  set 
  { 
    if ( paddingTopTitle != value )
    {
      paddingTopTitle = value; 
      Refresh(); 
    }
  }
}
Or:
public int PaddingTopTitle
{
  get 
  { 
    return _PaddingTopTitle; 
  }
  set 
  { 
    if ( _PaddingTopTitle!= value )
    {
      _PaddingTopTitle = value; 
      Refresh(); 
    }
  }
}
