     public class MyDog
    {
        public string Name;
        public int Age;
        public override bool Equals(object obj)
        {
            if (!(obj is MyDog other)) return false;
            return (this.Name == other.Name) && (this.Age == other.Age);
        }
    }
