c#
class MyObject
{
    public int Id { get; set; }
    public string State { get; set; }
}
public static void Main(string[] args)
{
    List<int> A = new List<int>()
    {
        1,
        2
    };
    List<MyObject> B = new List<MyObject>()
    {
        new MyObject() { Id = 1, State = "Idle" },
        new MyObject() { Id = 2, State = "Running" },
        new MyObject() { Id = 3, State = "Idle" },
    };
    // Where to filter elements by contidion
    var objectsFromA = B.Where(b => A.Contains(b.Id)); 
    Console.WriteLine("Filtered with Id-List 'A': " + string.Join(", ", objectsFromA.Select(s => "\"" + s.Id + ": " + s.State + "\"")));
    var onlyIdles = objectsFromA.Where(o => o.State == "Idle");
    Console.WriteLine("Filtered only Idle: " + string.Join(", ", onlyIdles.Select(s => "\"" + s.Id + ": " + s.State + "\"")));
    // Or in one single Where:
    Console.WriteLine("Filtered only Idle: " + string.Join(", ", B.Where(b => A.Contains(b.Id) && b.State == "Idle").Select(s => "\"" + s.Id + ": " + s.State + "\"")));
}
