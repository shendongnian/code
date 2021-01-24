       public class FolderStruct
    {
        public string FolderName { get; set; }
        public List<FolderStruct> FolderChildren { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FolderStruct FolderTree = new FolderStruct
            {
                FolderName = @"D:\",
                FolderChildren = new List<FolderStruct>()
            };
            LoadSubDirs(FolderTree);
            Console.ReadKey();
        }
        private static FolderStruct LoadSubDirs(FolderStruct FolderTree)
        {
            try
            {
                string[] subdirectories = Directory.GetDirectories(FolderTree.FolderName);
                if (subdirectories != null)
                {
                    foreach (string subdir in subdirectories)
                    {
                        var newFolder = new FolderStruct()
                        {
                            FolderName = subdir,
                            FolderChildren = new List<FolderStruct>()
                        };
                        var ret = LoadSubDirs(newFolder);
                        if (ret != null)
                            FolderTree.FolderChildren.Add(ret);
                    }
                    return FolderTree;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return null;
        }
    }
