lang-csharp
public void Main()
{
   Log(("today", DateTime.Today), ("tomorrow", DateTime.Today.AddDays(1)));
}
public void Log(params (string Name, object Value)[] values)
{
   foreach (var value in values)
   {
      Console.WriteLine($"{value.Name} => {value.Value}");
   }
}
