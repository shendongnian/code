        class PaddedFileSearch
    {
        public int LineLength { get; private set; }
        public FileInfo File { get; private set; }
        public PaddedFileSearch(FileInfo fileInfo)
        {
            var length = FindLineLength(fileInfo);
            //if (length == 0) throw new PaddedProgramException();
            LineLength = length;
            File = fileInfo;
        }
        private static int FindLineLength(FileInfo fileInfo)
        {
            using (var reader = new StreamReader(fileInfo.FullName))
            {
                string line;
                if ((line = reader.ReadLine()) != null)
                {
                    var length = line.Length + 2;
                    return length;
                }
            }
            return 0;
        }
        public void SeekMethod(List<int> lineNumbers)
        {
            Debug.Print("");
            Debug.Print("Line No\t\tPosition\t\tLine");
            Debug.Print("-------\t\t--------\t\t-----------------");
            lineNumbers.Sort();
            using (var fs = new FileStream(File.FullName, FileMode.Open))
            {
                lineNumbers.ForEach(ln => OutputData(fs, ln));
            }
        }
        private void OutputData(FileStream fs, int lineNumber)
        {
            var offset = (lineNumber - 1) * LineLength;
            fs.Seek(offset, SeekOrigin.Begin);
            var data = new byte[LineLength];
            fs.Read(data, 0, LineLength);
            var text = DecodeData(data);
            Debug.Print("{0,-12}{1,-16}{2}", lineNumber, offset, text);
        }
        private static string DecodeData(byte[] data)
        {
            var encoding = new UTF8Encoding();
            return encoding.GetString(data);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var seeker = new PaddedFileSearch(new FileInfo(@"D:\Desktop\Test.txt"));
            Debug.Print("File Line length: {0}", seeker.LineLength);
            seeker.SeekMethod(new List<int> { 5, 3, 4 });
            seeker.SeekMethod(new List<int> { 5, 3 });
        }
    }
 
