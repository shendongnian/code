    class Program
    {
        static void TraversePathToId(Org org, string id, List<string> path)
        {
            if (org.Id == id) path.Add(org.Name);
            foreach (var child in org.Orgs)
            {
                TraversePathToId(child, id, path);
                if (path.Any())
                {
                    path.Add(org.Name);
                    break;
                }
            }
        }
        static List<string> GetPath(Org root, string id)
        {
            List<string> path = new List<string>();
            TraversePathToId(root, id, path);
            path.Reverse();
            return path;
        }
        static void Main(string[] args)
        {
            Org root = new Org("Org1", "abc")
            {
                Orgs = new List<Org>
                {
                    new Org("Org2", "cvf"),
                    new Org("Org3", "grf")
                    {
                        Orgs = new List<Org>
                        {
                            new Org("Org4", "uyk")
                            {
                                Orgs = new List<Org>
                                {
                                    new Org("Org5", "suf"),
                                }
                            },
                            new Org("Org6", "vxl"),
                            new Org("Org7", "bmd"),
                        }
                    },
                    new Org("Org8", "pes"),
                }
            };
            GetPath(root, "suf").ForEach(name => Console.Write($"{name}\t"));
            Console.ReadLine();
        }
    }
    public class Org
    {
        public Org(string name, string id)
        {
            Name = name;
            Id = id;
            Orgs = new List<Org>();
        }
        public string Name { get; }
        public string Id { get; }
        public List<Org> Orgs { get; set; }
    }
