    private Dictionary<Object, List<Object>> _PossibleValues;
    public object Convert(Object data, ....)
    {
       if(PossibleValues.ContainsKey(data))
       {
          //return the possible values for the actual selected parent item
          return(PossibleValues(data);
       }
       return null;
    }
