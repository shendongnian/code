    class Program
    {
        public class NumberedXmlFile
        {
            public NumberedXmlFile(string fullPath)
            {
                FullPath = fullPath;
            }
            public string FullPath { get; set; }
            public int FileNumber
            {
                get
                {
                    string file = Path.GetFileNameWithoutExtension(FullPath);
                    return Convert.ToInt32(file);
                }
            }
        }
        static void Main(string[] args)
        {
            const int targetFileNameNumber = 4;
            const string directoryPathContainingFiles = @"C:\temp";
            IEnumerable<NumberedXmlFile> numberedXmlFiles = Directory.GetFiles(directoryPathContainingFiles).Select(f => new NumberedXmlFile(f));
            NumberedXmlFile theFileIamLookingFor = numberedXmlFiles.OrderBy(f => Math.Abs(f.FileNumber - targetFileNameNumber)).FirstOrDefault();
        }
    }
