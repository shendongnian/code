        void Main()
        {
            var strings = new string[]{"locA/locB","locA/locB/locH",
                             "locC/locD/locE","locC/locD/locE/locK","locF/locG"};
            var folders = Folder.Parse(strings);
            folders.Dump();
        }
        public class Folder
        {
            public string Name { get; set; }
            public List<Folder> Folders { get; internal set; }
            public Folder()
            {
                Folders = new List<Folder>();
            }
            //Presume that each string will be folder1/folder2/folder3
            public static IEnumerable<Folder> Parse(IEnumerable<string> locations)
            {
                var folders = new List<Folder>();
                foreach (string location in locations)
                {
                    string[] parts = location.Split('/');
                    Folder current = null;
                    foreach (string part in parts)
                    {
                        var useFolders = current != null ? 
                                   current.Folders : folders;
                        current = useFolders.SingleOrDefault(f => f.Name == part) ?? new Folder() { Name = part };
                        if (!useFolders.Contains(current)) { useFolders.Add(current); }
                    }
                }
                return folders;
            }
        }
