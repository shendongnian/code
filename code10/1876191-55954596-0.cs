    public class ObjectWhereIdReturnsPropAHashCode : IMyObject
    {
        public int Id
        {
            get => PropA?.GetHashCode() ?? 0;
            set => Id = value;
        }
        public string PropA { get; set; }
    } 
