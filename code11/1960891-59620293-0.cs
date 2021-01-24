    using System.Linq;
    enum Stuff
	{
	  UglyStuff,
	  BrokenStuff,
	  HappyStuff
	}
    public class MyStuff
    {
      public static List<string> MyList => System.Enum.GetNames(typeof(Stuff)).ToList();
    }
