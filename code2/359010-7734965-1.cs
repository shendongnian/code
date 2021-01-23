    public struct Data
    {
        public int id;
        public double x;
    }
    unsafe class A
    {
        Data* data;
        public A(Data* data)
        {
            this.data = data;
        }
        public int ID { get { return data->id; } set { data->id = value; } }
    }
    unsafe class B
    {
        Data* data;
        public B(Data* data)
        {
            this.data = data;
        }
        public double X { get { return data->x; } set { data->x = value; } }
    }
    unsafe class Program
    {
        static void Main(string[] args)
        {
            Data store = new Data();
            A a = new A(&store);
            B b = new B(&store);
            a.ID = 100;
            b.X = 3.33;
            Console.WriteLine("id={0} x={1}", store.id, store.x);
        }
    }
