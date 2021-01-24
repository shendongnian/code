    public class Student
    {
        public int Id { get; set; }
        public override string ToString()
        {
            return Id?.ToString();
        }
    }
    public class Admin
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        } 
    }
    public class Generic
    {
        public void Print<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item); // Implicitly calls ToString()
            }
        }
    }
