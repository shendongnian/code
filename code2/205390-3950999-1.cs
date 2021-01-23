    namespace ClassA
    {
        public class Human
        {
            public String Name { get; private set; }
            public int NetId { get; private set; }
    
            public Human(String name, int netId)
            {
                this.Name = name;
                this.NetId = netId;
            }
    
            public static void Main(string[] args)
            {
                Human human = new Human("Yoon Lee", 99);
                int expected = human.NetId; // parantheses not required for property-getter
            }
    
        }
    }
