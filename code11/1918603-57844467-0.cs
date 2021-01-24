c#
public class Node
{
    public Node(int id, int parentId, string name, List<Node> children)
    {
        Id = id;
        ParentId = parentId;
        Name = name;
        Children = children;
    }
    public int Id { get; }
    public int ParentId { get; }
    public string Name { get; }
    public List<Node> Children { get; }
}
The tree assembly by hand
c#
var tree =
    new Node(1, -1, "R", new List<Node>
    {
        new Node(2, 1, "C1R1", new List<Node>()),
        new Node(3, 1, "C2R2", new List<Node>()),
        new Node(4, 1, "C3R3", new List<Node>
        {
            new Node(5, 4, "C1R3", new List<Node>()),
            new Node(6, 4, "C2R3", new List<Node>
            {
                new Node(7, 6, "C1R3", new List<Node>())
            })
        })
    });
2. By setting Properties
The node class
c#
public class Node
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public List<Node> Children { get; set; }
}
The tree assembly by hand
c#
var tree =
    new Node
    {
        Id = 1,
        ParentId = -1,
        Name = "R",
        Children = new List<Node>
        {
            new Node
            {
                Id = 2,
                ParentId = 1,
                Name = "C1R1",
                Children = new List<Node>()
            },
            new Node
            {
                Id = 3,
                ParentId = 1,
                Name = "C2R2",
                Children = new List<Node>()
            },
            new Node
            {
                Id = 4,
                ParentId = 1,
                Name = "C3R3",
                Children = new List<Node>
                {
                    new Node
                    {
                        Id = 5,
                        ParentId = 4,
                        Name = "C1R3",
                        Children = new List<Node>()
                    },
                    new Node
                    {
                        Id = 6,
                        ParentId = 4,
                        Name = "C2R3",
                        Children = new List<Node>
                        {
                            new Node
                            {
                                Id = 7,
                                ParentId = 6,
                                Name = "C1R3",
                                Children = new List<Node>()
                            },
                        }
                    }
                }
            },
        }
    };
