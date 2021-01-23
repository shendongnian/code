    class Program
    {
        delegate int Del();
        static void Main(string[] args)
        {
            List<MyClass> connections = new List<MyClass>();
            connections.Add(new MyClass() { name = "a", mass = 5.001f });
            connections.Add(new MyClass() { name = "c", mass = 4.999f }); 
            connections.Add(new MyClass() { name = "b", mass = 4.2f });
            connections.Add(new MyClass() { name = "a", mass = 4.99f });
            MyClass maxConnection = connections.AsParallel().Max();
            Console.WriteLine("{0} {1} ", maxConnection.name, maxConnection.mass);
            Console.ReadLine();
        }
        class MyClass : IComparable
        {
            public string name { get; set; }
            public float mass { get; set; }
            public int CompareTo(object obj)
            {
                return (int)(mass - ((MyClass)obj).mass);
            }
        }
    }
