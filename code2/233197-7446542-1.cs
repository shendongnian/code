    void Main()
    {
      string json = @"
      {
        'glossary': 
        {
          'title': 'example glossary',
            'GlossDiv': 
            {
              'title': 'S',
              'GlossList': 
              {
                'GlossEntry': 
                {
                  'ID': 'SGML',
                  'ItemNumber': 2,			
                  'SortAs': 'SGML',
                  'GlossTerm': 'Standard Generalized Markup Language',
                  'Acronym': 'SGML',
                  'Abbrev': 'ISO 8879:1986',
                  'GlossDef': 
                  {
                    'para': 'A meta-markup language, used to create markup languages such as DocBook.',
                    'GlossSeeAlso': ['GML', 'XML']
                  },
                  'GlossSee': 'markup'
                }
              }
            }
        }
      }
    
      ";
    
      var d = new JsonDeserializer(json);
      d.GetString("glossary.title").Dump();
      d.GetString("glossary.GlossDiv.title").Dump();  
      d.GetString("glossary.GlossDiv.GlossList.GlossEntry.ID").Dump();  
      d.GetInt("glossary.GlossDiv.GlossList.GlossEntry.ItemNumber").Dump();    
      d.GetObject("glossary.GlossDiv.GlossList.GlossEntry.GlossDef").Dump();   
      d.GetObject("glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso").Dump(); 
      d.GetObject("Some Path That Doesnt Exist.Or.Another").Dump();   
    }
    
    
    // Define other methods and classes here
    
    public class JsonDeserializer
    {
      private IDictionary<string, object> jsonData { get; set; }
    
      public JsonDeserializer(string json)
      {
        var json_serializer = new JavaScriptSerializer();
    
        jsonData = (IDictionary<string, object>)json_serializer.DeserializeObject(json);
      }
    
      public string GetString(string path)
      {
        return (string) GetObject(path);
      }
    
      public int? GetInt(string path)
      {
        int? result = null;
    
        object o = GetObject(path);
        if (o == null)
        {
          return result;
        }
    
        if (o is string)
        {
          result = Int32.Parse((string)o);
        }
        else
        {
          result = (Int32) o;
        }
    
        return result;
      }
    
      public object GetObject(string path)
      {
        object result = null;
    
        var curr = jsonData;
        var paths = path.Split('.');
        var pathCount = paths.Count();
    
        try
        {
          for (int i = 0; i < pathCount; i++)
          {
            var key = paths[i];
            if (i == (pathCount - 1))
            {
              result = curr[key];
            }
            else
            {
              curr = (IDictionary<string, object>)curr[key];
            }
          }
        }
        catch
        {
          // Probably means an invalid path (ie object doesn't exist)
        }
    
        return result;
      }
    }
