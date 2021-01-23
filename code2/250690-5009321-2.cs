    bool Compare(object valueToCompare)
    {
       Type t = valueToCompare.GetType();
       if(t.IsArray() && !t.GetElementType().IsValueType && t.GetRank() == 1)
       {
          foreach(var value in (valueToCompare as object[]))
              return Compare(value);
       }
       else
       {
           return Compare(valueToCompare);
       }
    }
