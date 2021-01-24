    public class ClassA
    {
        public int GroupNumber {get; set;}
        public string Name {get; set;}
        public bool IsAvailable {get; set;}
    
        public ClassA(string name, int groupNumber = 1, bool isAvailable = true)
        {
            Name = name;
            GroupNumber = groupNumber;
            IsAvailable = isAvailable;
        }
    }
