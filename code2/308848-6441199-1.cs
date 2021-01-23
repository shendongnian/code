    public class Files
    {
        public DateTime ModifiedTime { get; set; }
        public bool IsFile { get; set; }
        public string Name { get; set; }
    
        public Files(string line)
        {
            // Gets the date part and parse to DateTime
            ModifiedTime = DateTime.Parse(line.Substring(0, 16));
            // Gets the file information part and split
            // in two parts
            var fileBlock = line.Substring(17).Split(new char[] { ' ' }, 2);
            // first part tells if it is a file
            IsFile = fileBlock[0] != "<DIR>";
            // second part tells the name
            Name = fileBlock[1];
        }
    }
    
    static void Main(string[] args)
    {
        // DateTime: 02-17-11 01:39PM
        // IsFile  : false
        // Name    : dec
        var file3 = new Files("02-17-11 01:39PM <DIR> dec");
        // DateTime: 05-10-11 07:09PM
        // IsFile  : true
        // Name    : out put.xlsx
        var file4 = new Files("05-10-11 07:09PM 87588 out put.xlsx");
    }
    
