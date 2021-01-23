    //hyphens are not valid in identifiers
    namespace ClassA
    {
        public class Human
        {
            // these properties are publicly gettable but can only be set privately
            public string Name { get; private set; } 
            public int NetId { get; private set; }
    
            public Human(string name, int netId)
            {
                this.Name = name;
                this.NetId = netId;
            }
    
            // unlike Java, the entry-point Main method begins with a capital 'M'
            public static void Main(string[] args)
            {
                Human human = new Human("Yoon Lee", 99);
                int expected = human.NetId; // parantheses not required for property-getter
            }
    
        }
    }
