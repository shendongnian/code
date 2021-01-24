    public class RulesMyProperties : IRules<ClassAbstract>
    {
      public List<ClassAbstract> SetAdditionalPropRules(List<ClassAbstract> myList)
      {
        foreach ( var item in myList.ToList() )
        {
          if ( item != null )
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
                  NAME = "Joe",
                  AGE = 30,
                  JOB = "Tester"
                });
              }
              break;
            }
        }
        return myList;
      }
