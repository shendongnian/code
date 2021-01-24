private class Child
{
    public string Name { get; set; }
    public List<Child> Children { get; set; }
}
public static void Main()
{
    var children = new List<Child>(){
        new Child{
            Name = "C1",
            Children = new List<Child>{
                new Child{ Name = "C1_C1"},
                new Child{ Name = "C1_C2"}
            }},
        new Child{
            Name = "C2",
            Children = new List<Child>{
                new Child{ Name = "C2_C1"},
                new Child{ Name = "C2_C2"}
            }}
        };
    var granchildren = children.SelectMany( c => c.Children);
    Console.WriteLine(string.Join(", ", granchildren.Select(c => c.Name)));
}
The snippet above outputs the following:
C1_C1, C1_C2, C2_C1, C2_C2
