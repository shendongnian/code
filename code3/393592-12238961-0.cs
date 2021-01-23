    IComparable GetPropValue( object src, string propName )
    {
      return (IComparable)src.GetType( ).GetProperty( propName ).GetValue( src, null );
    }
    
    IEnumerable<Premise> SortMyPremises(IEnumerable<Premise> premises, string propertyName, string ascendingOrDescending) 
    {
      return ascendingOrDescending = "ascending" 
        ? premises.OrderBy(p => GetPropValue(p, propertyName)) 
        : premises.OrderByDescending(p => GetPropValue(p, propertyName));
    }
