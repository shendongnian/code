    class Obj {
        private long pos;
        public ref long Position { get { return ref pos; } }
    }
    static void Main(string[] args)
    {
            Obj[] arr = new Obj[2] { new Obj(), new Obj() };
            arr[0].Position = 10;
            arr[1].Position = 20;
            int index = 0;
            WriteLine($"{arr[index].Position}, {arr[index+1].Position}");
            Swap<long>(ref arr[index].Position, ref arr[index+1].Position);
            WriteLine($"{arr[index].Position}, {arr[index+1].Position}");
    }
