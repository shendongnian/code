    public struct LineType
    {
        public string Email { get; set; }
        public string Others { get; set; }
    
        public override bool Equals(object obj)
        {
            return this.Email.Equals(((LineType)obj).Email);
        }
    }
    private static void WorkOnFile(string filePath)
    {
        StreamReader stream = File.OpenText(filePath);
    
        HashSet<LineType> hashSet = new HashSet<LineType>();
    
        while (true)
        {
            string line = stream.ReadLine();
            if (line == null)
                break;
    
            string new_line = string.Join("|", line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
    
                    
            LineType lineType = new LineType()
            {
                Email = new_line.Split('|')[3],
                Others = new_line
            };
    
            if (!hashSet.Contains(lineType))
                hashSet.Add(lineType);
        }
    }
