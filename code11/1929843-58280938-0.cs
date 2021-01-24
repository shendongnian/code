    public class RulesMyProperties : IRules<ClassAbstract>
    {
      public List<ClassAbstract> SetAdditionalPropRules(List<ClassAbstract> myList)
      {
        foreach ( var item in myList.ToList() )
        {
          if ( item.NAME == "Joe" )
          {
            if ( item is Class1 )
            {
              ( item as Class1 ).AGE = 30;
              ( item as Class1 ).JOB = "Tester";
            }
            else
            {
              myList.Remove(item);
              myList.Add(new Class1
              {
                AGE = 30,
                JOB = "Tester"
              });
            }
            break;
          }
        }
        return null;
      }
      public List<ClassAbstract> GetAdditionalPropRules(List<ClassAbstract> list1)
      {
        throw new NotImplementedException();
      }
    }
