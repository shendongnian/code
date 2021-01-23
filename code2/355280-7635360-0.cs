    public class Device
    {
        public string Name;
        public List<Group> Groups = new List<Group>();
    }
    public class Group
    {
        public string Name;
        public List<Pin> Pins = new List<Pin>();
    }
    public class Pin
    {
        public string Name;
        public string Result;
    }
