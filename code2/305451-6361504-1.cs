    class YourType
    {
       string Name;
       string Type;
       string Quantity;
    }
    
    abstract class Test
    {
       public abstract bool RunTest(YourType o);
    }
    
    class AndTest : Test
    {
       public List<Test> Children;
       public bool RunTest(YourType o)
       {
          foreach (var test in Children)
          {
             if (!test.RunTest(o)) return false;
          }
          return true;
       }
    }
    
    class OrTest : Test
    {
       public List<Test> Children;
       public bool RunTest(YourType o)
       {
          foreach (var test in Children)
          {
             if (test.RunTest(o)) return true;
          }
          return false;
       }
    }
    
    class NameTest : Test
    {
       public string Match;
    
       public bool RunTest(YourType o)
       {
          return o.Name.Contains(Match);
       }
    }
    
    class TypeTest : Test
    {
       public string Match;
    
       public bool RunTest(YourType o)
       {
          return o.Type.Contains(Match);
       }
    }
