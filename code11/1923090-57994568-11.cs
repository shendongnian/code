    class MyObject : IComparable<MyObject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public int CompareTo(MyObject other)
        {
            return string.Compare(this.Name, other.Name);
        }
    }
    // then
    myList.Sort();
