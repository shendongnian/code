    using System.DirectoryServices;
    using System.Threading.Tasks;
    public class ADTree
    {
        DirectoryEntry rootOU = null;
        string rootDN = string.Empty;
        List<ADTree> childOUs = new List<ADTree>();
        public DirectoryEntry RootOU
        {
            get { return rootOU; }
            set { rootOU = value; }
        }
        public string RootDN
        {
            get { return rootDN; }
            set { rootDN = value; }
        }
        public List<ADTree> ChildOUs
        {
            get { return childOUs; }
            set { childOUs = value; }
        }
        public ADTree(string dn)
        {
            RootOU = new DirectoryEntry(dn);
            RootDN = dn;
            BuildADTree().Wait();
        }
        public ADTree(DirectoryEntry root)
        {
            RootOU = root;
            RootDN = root.Path;
            BuildADTree().Wait();
        }
        private Task BuildADTree()
        {
            return Task.Factory.StartNew(() =>
            {
                object locker = new object();
                Parallel.ForEach(RootOU.Children.Cast<DirectoryEntry>().AsEnumerable(), child =>
                {
                    if (child.SchemaClassname.Equals("organizationalUnit"))
                    {
                        ADTree ChildTree = new ADTree(child);
                        lock (locker)
                        {
                            ChildOUs.Add(ChildTree);
                        }
                    }
                });
            });
        }
    }
