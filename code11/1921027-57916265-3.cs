    public class BaseVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            return obj is BaseVM &&
                   ((BaseVM) obj).ID == ID;
        }
        public override int GetHashCode()
        {
            return ID;
        }
    }
