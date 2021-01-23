    public class SysConfig
    {
       [OptionalValidationAttributeHere]
       public static string SystemType {get;set;}
       public static Action DoSomethingDependsOnSystemType()
       {
          //return different actions
       }
    }
