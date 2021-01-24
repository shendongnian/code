 txt
596 bytes
100 items
95, 95
96, 96
97, 97
98, 98
99, 99
with code:
 c#
using ProtoBuf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
static class P
{
    static void Main()
    {
        var houses = new List<Houses>();
        for (int i = 0; i < 100; i++)
            houses.Add(new Houses(i, i));
        using(var ms = new MemoryStream())
        {
            Serializer.Serialize(ms, houses);
            System.Console.WriteLine($"{ms.Length} bytes");
            ms.Position = 0;
            var clone = Serializer.Deserialize<List<Houses>>(ms);
            System.Console.WriteLine($"{clone.Count} items");
            foreach(var item in clone.Skip(95))
            {
                System.Console.WriteLine($"{item.Id}, {item.People}");
            }
        }
    }
}
[ProtoContract(SkipConstructor = true)]
public class Houses
{
    [ProtoMember(1)]
    public int Id { get; set; }
    [ProtoMember(2)]
    public int People { get; set; }
    public Houses(int id, int people)
    {
        Id = id;
        People = people;
    }
}
