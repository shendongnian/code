    private void InspectRecursively(object input,
        Dictionary<object, bool> processedObjects)
    {
      if ((input != null) && !processedObjects.ContainsKey(input))
      {
        processedObjects.Add(input, true);
        List<FieldInfo> fields = type.GetFields(BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic );
        foreach (FieldInfo field in fields)
        {
          object nextInput = field.GetValue(input);
                
          if (nextInput is System.Collections.IEnumerable)
          {
            System.Collections.IEnumerator enumerator = (nextInput as
                System.Collections.IEnumerable).GetEnumerator();
  
            while (enumerator.MoveNext())
            {
              InspectRecursively(enumerator.Current, processedObjects);
            }
          }
          else
          {
            InspectRecursively(nextInput, processedObjects);
          }
        }
      }
    }
