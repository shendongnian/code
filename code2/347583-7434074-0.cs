    static void Main(string[] args)
        {
            var folders = new[] { "Folder1","Folder2","Folder2/ChildFolder","Folder2/ChildFolder2","Folder2/ChildFolder3",
                                  "Folder2/ChildFolder3/Folderrrr", "Folder2/ChildFolder3/Hi"
                                };
            var root = new Dir();
            foreach (var folder in folders)
            {
                BuildTree(folder, root);
            }
            Console.ReadLine();
        }
        private static void BuildTree(string path, Dir parent)
        {
            if (path.Contains("/"))
            {
                var dir = path.Substring(0, path.IndexOf("/"));
                var newPath = path.Substring(dir.Length + 1);
                var addNodeTo = parent;
                if (!parent.Contains(dir))
                {
                    var newParent = new Dir { Name = dir };
                    parent.Dirs.Add(newParent);
                    addNodeTo = newParent;
                }
                else
                {
                    addNodeTo = parent.Get(dir);
                }
                BuildTree(newPath, addNodeTo);
            }
            else
            {
                if (!parent.Contains(path))
                    parent.Dirs.Add(new Dir { Name = path });
            }
        }
    }
    public class Dir
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public List<Dir> Dirs { get; set; }
        public Dir()
        {
            Dirs = new List<Dir>();
        }
        public bool Contains(string name)
        {
            return Dirs.Any(d => d.Name.Equals(name));
        }
        public Dir Get(string name)
        {
            return Dirs.FirstOrDefault(d => d.Name.Equals(name));
        }
        public override string ToString()
        {
            return Name;
        }
    }
