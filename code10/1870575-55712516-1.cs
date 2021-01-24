public void CheckData()
{
    if(n == null)
    {
       Console.Write("n is null");
    }
    if (b == null)
    {
       Console.Write("b is null");
    }
    if (s == null)
    {
        Console.Write("s is null");
    }
}
Run a method like that after json maps to the object to see if there were any still null.
Or you can try something like this
var fields = typeof(MyClass).GetFields();
            foreach (var field in fields)
            {
                if(!json.ContainsKey(field.Name))
                {
                    Console.Write($"{field.Name} is missing");
                }
            }
