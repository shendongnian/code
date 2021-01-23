    public class Person : IComparable<Person>
    {
            public enum Types: int {
                None,
                Child,
                Father,
                Grandfather,
                GrandGrandFather
            }
        public Types ID { get; set; }
        public Types ParentID { get; set; }
    
        public Person(Types id, Types pid)
        {
            this.ID = id;
            this.ParentID = pid;
        }
    
        public Int32 CompareTo(Person right)
        {
            return this.ParentID.CompareTo(right.ID);
        }
    
    }
