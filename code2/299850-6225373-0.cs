    class TreeNode
    {
        public int Id;
        public int? ParentId;
    }
    static void Main(string[] args)
    {
        var list = new List<TreeNode>{
            new TreeNode{ Id = 1 },
                new TreeNode{ Id = 4, ParentId = 1 },
                new TreeNode{ Id = 5, ParentId = 1 },
                new TreeNode{ Id = 6, ParentId = 1 },
            new TreeNode{ Id = 2 },
                new TreeNode{ Id = 7, ParentId= 2 },
                    new TreeNode{ Id = 8, ParentId= 7 },
            new TreeNode{ Id = 3 },
        };
        foreach (var item in Level(list, null, 0))
        {
            Console.WriteLine("Id={0}, Level={1}", item.Key, item.Value);
        }
    }
    private static IEnumerable<KeyValuePair<int,int>> Level(List<TreeNode> list, int? parentId, int lvl)
    {
        return list
            .Where(x => x.ParentId == parentId)
            .SelectMany(x => 
                new[] { new KeyValuePair<int, int>(x.Id, lvl) }.Concat(Level(list, x.Id, lvl + 1))
            );
    }
