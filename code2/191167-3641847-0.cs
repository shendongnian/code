    public class PriorityItem<DataType, ComparerType> : IComparable<PriorityItem<DataType, ComparerType>>
        where ComparerType : IComparable
    {
        public DataType Data { get; set; }
        public ComparerType Priority { get; set; }
        public PriorityItem(DataType data, ComparerType priority)
        {
            Data = data;
            Priority = priority;
        }
        public string ToString()
        {
            return Priority.ToString();
        }
        public int CompareTo(PriorityItem<DataType, ComparerType> other)
        {
            if (other == null) return 1;
            return Priority.CompareTo(other.Priority);
        }
        public int CompareTo(object other)
        {
            return CompareTo(other as PriorityItem<DataType, ComparerType>);
        }
    }
    public class PriorityItem<DataAndComparerType> : PriorityItem<DataAndComparerType, DataAndComparerType>
        where ComparerType : IComparable
    {
        public PriorityItem(DataAndComparerType data) : base(data, data)
        {
        }
    }
