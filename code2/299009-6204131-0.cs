    public class Toto
    {
        String test1 = "aaa";
        int test2 = 0;
    }
    // -------------
	Toto t = new Toto();
	var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
	foreach (FieldInfo field in t.GetType().GetFields(flags))
	{
		Console.WriteLine(field.Name + " : " + field.GetValue(t));
	}
