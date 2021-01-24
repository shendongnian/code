    public class RequestDto
    {
        public RequestDto()
        {
            TypeNames = new HashSet<string>();
            TypeNames.Add(new string("Type1"));
            TypeNames.Add(new string("Type2"));
            TypeNames.Add(new string("Type3"));
        }
        public string CompanyName { get; set; }
        public string Version { get; set; }
        public ISet<string> TypeNames { get; set; }
    }
