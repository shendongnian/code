         interface IClassAbsract
             {
                 string Name { get; set; }
                 string Age { get; set; }
             }
             public class Class1: IClassAbsract
             {
                 public string Name { get; set; }
                 public string Age { get; set; }
             }
             public class Class2 : IClassAbsract
             {
                 public string Name { get; set; }
                 public string Age { get; set; }
             }
             public class ListRule
             {
                 public List<IClassAbsract> List { get; set; } = new List<IClassAbsract>();
             }
			 
			 
