`
using System;
using System.Linq;
using System.Collections.Generic;
namespace ConsoleApp
{
  static partial class Program
  {
`
`
    static void Main(string[] args)
    {
      Test();
      Console.WriteLine();
      Console.WriteLine("End.");
      Console.ReadKey();
    }
`
`
    static void Test()
    {
      var rules = new RulesMyProperties();
      var list = new List<ClassAbstract>();
      list.Add(new Class1 { NAME = "Joe", AGE = 20 });
      list.Add(new Class2 { NAME = "Joe", AGE = 25 });
      list.Add(new Class1 { NAME = "John", AGE = 30 });
      list.Add(new Class2 { NAME = "John", AGE = 35 });
      Action print = () =>
      {
        foreach ( var item in list )
        {
          Console.Write($"{item.NAME} / {item.GetType().Name} : {item.AGE}");
          if ( item is Class1 )
            Console.Write($" ({((Class1)item).JOB})");
          Console.WriteLine();
        }
      };
      print();
      rules.SetAdditionalPropRules(list);
      Console.WriteLine();
      print();
    }
`
`
  }
`
`
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
    public List<ClassAbstract> GetAdditionalPropRules(List<ClassAbstract> list1)
    {
      throw new NotImplementedException();
    }
  }
`
`
  public interface IRules<T>
  {
    List<T> GetAdditionalPropRules(List<T> list1);
    List<T> SetAdditionalPropRules(List<T> list1);
  }
`
`
  public class ClassAbstract
  {
    public string NAME { get; set; }
    public int AGE { get; set; }
  }
`
`
  public class Class1 : ClassAbstract
  {
    public string JOB { get; set; }
  }
`
`
  public class Class2 : ClassAbstract
  {
  }
`
`
}
`
Results:
`
Joe / Class1 : 20 ()
Joe / Class2 : 25
John / Class1 : 30 ()
John / Class2 : 35
Joe / Class1 : 30 (Tester)
Joe / Class2 : 25
John / Class1 : 30 ()
John / Class2 : 35
`
