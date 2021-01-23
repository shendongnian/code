    public class Files
    {
        public DateTime ModifiedTime { get; set; }
        public bool IsFile { get; set; }
        public string Name { get; set; }
    
        public Files(GroupCollection g)
        {
            ModifiedTime = DateTime.Parse(g[1].Value);
            IsFile = g[2].Value != "<DIR>";
            Name = g[3].Value;
        }
    }
    
    static void Main(string[] args)
    {
        var p = @"(\d{2}-\d{2}-\d{2} \d{2}:\d{2}(?:PM|AM)) (<DIR>|\d+) (.+)";
        var regex = new Regex(p, RegexOptions.IgnoreCase);
    
        var m1 = regex.Match("02-17-11 01:39PM <DIR> dec");
        var m2 = regex.Match("05-10-11 07:09PM 87588 output.xlsx");
        // DateTime: 02-17-11 01:39PM
        // IsFile  : false
        // Name    : dec
        var file1 = new Files(m1.Groups);
        // DateTime: 05-10-11 07:09PM
        // IsFile  : true
        // Name    : output.xlsx
        var file2 = new Files(m2.Groups);
    }
