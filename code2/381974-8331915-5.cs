    [AttributeUsage(AttributeTargets.All/*, AllowMultiple = true*/)]
    public class WarningAttribute : System.attribute
    {
       public readonly string Warning;
    
       public WarningAttribute(string warning)
       {
          this.Warning = warning;
       }    
    }
