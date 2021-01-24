    public Tuple<string, string> GetElementTupleFor<T>(object objToQuery, T obj)
    {
        foreach(FieldInfo field in ListOfFields)
        {
           var elements = field.GetValue(objToQuery);
           for(int i=0; i<elements.Count; i++)
           {
              if (obj == elements[i])
              {
                 return new Tuple<string, string>(field.Name, ""+i);
              }
           }
        }
        return new Tuple<string, string>("NotFound", "?");
     }
